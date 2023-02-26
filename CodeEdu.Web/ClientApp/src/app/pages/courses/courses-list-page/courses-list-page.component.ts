import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { CourseDto } from 'src/app/api/client';
import { CoursesAddDialogComponent } from 'src/app/features/courses-add-dialog/courses-add-dialog.component';

@Component({
  selector: 'app-courses-page',
  templateUrl: './courses-list-page.component.html',
  styleUrls: ['./courses-list-page.component.css'],
})
export class CoursesListPageComponent implements OnInit {
  public refreshSubject: Subject<void> = new Subject();

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {}

  public openAddCourseDialog() {
    const coursesAddDialogRef = this.dialog.open(CoursesAddDialogComponent);
    coursesAddDialogRef.afterClosed().subscribe(() => {
      this.refreshSubject.next();
    });
  }
}
