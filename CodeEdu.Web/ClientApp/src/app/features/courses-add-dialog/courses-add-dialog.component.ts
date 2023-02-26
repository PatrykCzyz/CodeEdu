import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AddCourseDto, CoursesClient } from 'src/app/api/client';

@Component({
  selector: 'app-courses-add-dialog',
  templateUrl: './courses-add-dialog.component.html',
  styleUrls: ['./courses-add-dialog.component.scss'],
})
export class CoursesAddDialogComponent {
  public form: FormGroup<AddCourseForm>;
  public loading: boolean = false;

  constructor(
    private _client: CoursesClient,
    private _dialogRef: MatDialogRef<CoursesAddDialogComponent>) {
    this.form = new FormGroup<AddCourseForm>({
      name: new FormControl('', {
        nonNullable: true,
        validators: [Validators.minLength(3), Validators.maxLength(30)],
      }),
      description: new FormControl('', { nonNullable: true }),
    });
  }

  onSubmit() {
    if (this.form.invalid) {
      return;
    }

    const { name, description } = this.form.value;

    this._client.addCourse(new AddCourseDto({ name, description })).subscribe({
      next: () => {
        this._dialogRef.close();
      },
      complete: () => (this.loading = false),
    });
  }
}

interface AddCourseForm {
  name: FormControl<string>;
  description: FormControl<string>;
}
