import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {
  CdkDragDrop,
  moveItemInArray,
} from '@angular/cdk/drag-drop';
import { CourseDto, CoursesClient, SubjectDto, SubjectOrderDto } from 'src/app/api/client';
import { CoursesFormDialogComponent } from '../courses-form-dialog/courses-form-dialog.component';

@Component({
  selector: 'app-change-subjects-order-dialog',
  templateUrl: './change-subjects-order-dialog.component.html',
  styleUrls: ['./change-subjects-order-dialog.component.scss'],
})
export class ChangeSubjectsOrderDialogComponent implements OnInit {
  public course: CourseDto;
  public subjects: SubjectDto[];

  constructor(
    private _dialogRef: MatDialogRef<CoursesFormDialogComponent>,
    private _coursesClient: CoursesClient,
    @Inject(MAT_DIALOG_DATA) data: ChangeSubjectsOrderDialogData
  ) {
    this.course = data.course;
    this.subjects = data.course.subjects!.map(e => ({...e} as SubjectDto));
  }

  ngOnInit(): void {}

  public drop(event: CdkDragDrop<CourseDto[]>) {
    moveItemInArray(
      this.subjects,
      event.previousIndex,
      event.currentIndex,
    );
  }

  public save() {
    const subjectOrders = this.subjects?.map(
      ({ id: subjectId }, index) => new SubjectOrderDto({ subjectId, number: index + 1 })
    );

    if (subjectOrders) {
      this._coursesClient
        .changeSubjectsOrder(this.course.id!, subjectOrders)
        .subscribe(() => this._dialogRef.close({ success: true }));
    }
  }
}

interface ChangeSubjectsOrderDialogData {
  course: CourseDto;
}

export interface ChangeSubjectsOrderDialogResult {
  success: boolean;
}
