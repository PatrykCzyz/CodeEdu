import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CourseDto, CoursesClient } from 'src/app/api/client';
import { ConfirmationDialogComponent } from '../../confirmation-dialog/confirmation-dialog.component';

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

  public deleteCourse(course: CourseDto) {
    const deleteConfirmationDialog = this.dialog.open(
      ConfirmationDialogComponent,
      {
        data: {
          title: 'Czy na pewno chcesz usunąć kurs',
          content: course.name,
          confirmText: 'Usuń',
        },
      }
    );

    deleteConfirmationDialog.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this._coursesClient
          .removeCourse(course.id!)
          .subscribe(() => this.cardRemoved.emit());
      }
    });
  }
}
