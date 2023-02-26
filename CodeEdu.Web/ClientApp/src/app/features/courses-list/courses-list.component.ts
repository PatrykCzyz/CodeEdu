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

  constructor(private _coursesClient: CoursesClient) {}

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

  public onCardRemoved() {
    this._getCourses();
  }

  private _getCourses() {
    this._coursesClient.getCourses().subscribe((res) => {
      this.courses = res.sort(
        (a, b) => b.createdAt!.getTime() - a.createdAt!.getTime()
      );
    });
  }
}
