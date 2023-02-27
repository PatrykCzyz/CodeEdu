import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CourseDto, CoursesClient } from 'src/app/api/client';
import {
  ChangeSubjectsOrderDialogComponent,
  ChangeSubjectsOrderDialogResult,
} from '../../change-subjects-order-dialog/change-subjects-order-dialog.component';
import { ConfirmationDialogComponent } from '../../confirmation-dialog/confirmation-dialog.component';
import {
  CoursesFormDialogComponent,
  CoursesFormDialogResult,
} from '../../courses-form-dialog/courses-form-dialog.component';
import { SubjectAddDialogComponent } from '../../subject-add-dialog/subject-add-dialog.component';

@Component({
  selector: 'app-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.scss'],
})
export class CourseCardComponent implements OnInit {
  @Input()
  public course!: CourseDto;

  @Output()
  public cardRemoved: EventEmitter<void> = new EventEmitter();

  public shouldShowMore: boolean = false;

  public get canChangeOrder() {
    return (this.course.subjects?.length ?? 0) > 0;
  }

  constructor(
    private dialog: MatDialog,
    private _coursesClient: CoursesClient
  ) {}

  ngOnInit(): void {}

  public getDescription(course: CourseDto) {
    if (
      !course.description ||
      course.description.length <= 258 ||
      this.shouldShowMore
    )
      return course.description;

    return course.description.substring(0, 255) + '...';
  }

  public getSortedSubjects(course: CourseDto) {
    return course.subjects?.sort((a, b) => a.number! - b.number!);
  }

  public showMore(value: boolean) {
    this.shouldShowMore = value;
  }

  public addSubject() {
    const subjectAddDialogRef = this.dialog.open(SubjectAddDialogComponent, {
      data: { course: this.course },
    });
    subjectAddDialogRef.afterClosed().subscribe(() => {
      this.refreshCourse();
    });
  }

  public changeSubjectsOrder() {
    const changeSubjectsOrderDialogRef = this.dialog.open(
      ChangeSubjectsOrderDialogComponent,
      {
        data: { course: this.course },
      }
    );
    changeSubjectsOrderDialogRef
      .afterClosed()
      .subscribe((result: ChangeSubjectsOrderDialogResult) => {
        if (result.success) {
          this.refreshCourse();
        }
      });
  }

  public editCourse() {
    const courseEditDialogRef = this.dialog.open(CoursesFormDialogComponent, {
      data: {
        course: this.course,
      },
    });
    courseEditDialogRef
      .afterClosed()
      .subscribe((result: CoursesFormDialogResult) => {
        if (result.success) {
          this.refreshCourse();
        }
      });
  }

  public deleteCourse() {
    const deleteConfirmationDialog = this.dialog.open(
      ConfirmationDialogComponent,
      {
        data: {
          title: 'Czy na pewno chcesz usunąć kurs',
          content: this.course.name,
          confirmText: 'Usuń',
        },
      }
    );

    deleteConfirmationDialog.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this._coursesClient
          .removeCourse(this.course.id!)
          .subscribe(() => this.cardRemoved.emit());
      }
    });
  }

  private refreshCourse() {
    this._coursesClient
      .getCourse(this.course.id!)
      .subscribe((course) => (this.course = course));
  }
}
