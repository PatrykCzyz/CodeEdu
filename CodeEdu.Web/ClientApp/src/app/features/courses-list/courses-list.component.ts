import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { CourseDto, CoursesClient } from 'src/app/api/client';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.scss'],
})
export class CoursesListComponent implements OnInit, OnDestroy {
  @Input()
  public refreshSubject?: Subject<void>;

  public courses: CourseDto[] = [];

  constructor(
    private _coursesClient: CoursesClient,
    private dialog: MatDialog
  ) {}

  ngOnDestroy(): void {
    this.refreshSubject?.unsubscribe();
  }

  ngOnInit(): void {
    this._getCourses();
    this.refreshSubject?.subscribe(() => this._getCourses());
  }

  public identify(index: number, course: CourseDto) {
    return course.id;
  }

  public getDescription(course: CourseDto) {
    if (!course.description) return '';

    if (course.description.length <= 258) return course.description;

    return course.description.substring(0, 255) + '...';
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
          .subscribe(() => this._getCourses());
      }
    });
  }

  private _getCourses() {
    this._coursesClient.getCourses().subscribe((res) => {
      this.courses = res.sort(
        (a, b) => b.createdAt!.getTime() - a.createdAt!.getTime()
      );
    });
  }
}
