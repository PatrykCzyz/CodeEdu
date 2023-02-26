import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddSubjectDto, CourseDto, CoursesClient } from 'src/app/api/client';

@Component({
  selector: 'app-subject-add-dialog',
  templateUrl: './subject-add-dialog.component.html',
  styleUrls: ['./subject-add-dialog.component.scss'],
})
export class SubjectAddDialogComponent {
  public form: FormGroup<AddSubjectForm>;
  public loading: boolean = false;
  public course: CourseDto;

  constructor(
    private _client: CoursesClient,
    private _dialogRef: MatDialogRef<SubjectAddDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SubjectAddDialogData
  ) {
    this.course = data.course;

    this.form = new FormGroup<AddSubjectForm>({
      name: new FormControl('', {
        nonNullable: true,
        validators: [Validators.minLength(3), Validators.maxLength(40)],
      }),
    });
  }

  onSubmit() {
    if (this.form.invalid) {
      return;
    }

    const { name } = this.form.value;

    this._client.addSubjectToCourse(this.course.id!, new AddSubjectDto({ name })).subscribe({
      next: () => {
        this._dialogRef.close();
      },
      complete: () => (this.loading = false),
    });
  }
}

interface AddSubjectForm {
  name: FormControl<string>;
}

interface SubjectAddDialogData {
  course: CourseDto;
}
