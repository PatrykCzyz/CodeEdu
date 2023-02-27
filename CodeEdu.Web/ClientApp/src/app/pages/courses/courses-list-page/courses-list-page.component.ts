import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { AddCourseDto, CourseDto, CoursesClient } from 'src/app/api/client';
import {
  CoursesFormDialogComponent,
  CoursesFormDialogResult,
} from 'src/app/features/courses-form-dialog/courses-form-dialog.component';

@Component({
  selector: 'app-courses-page',
  templateUrl: './courses-list-page.component.html',
  styleUrls: ['./courses-list-page.component.css'],
})
export class CoursesListPageComponent implements OnInit {
  public refreshSubject: Subject<void> = new Subject();

  constructor(private _dialog: MatDialog, private _client: CoursesClient) {}

  ngOnInit(): void {}

  public openAddCourseDialog() {
    const coursesAddDialogRef = this._dialog.open(CoursesFormDialogComponent);
    coursesAddDialogRef
      .afterClosed()
      .subscribe((result: CoursesFormDialogResult) => {
        if (result.success) {
          this.refreshSubject.next();
        }
      });
  }
}
