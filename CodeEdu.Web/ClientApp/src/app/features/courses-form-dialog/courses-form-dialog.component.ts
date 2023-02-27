import { Component, Inject, Input, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import {
  AddCourseDto,
  CourseDto,
  CoursesClient,
  EditCourseDto,
} from 'src/app/api/client';

@Component({
  selector: 'app-courses-form-dialog',
  templateUrl: './courses-form-dialog.component.html',
  styleUrls: ['./courses-form-dialog.component.scss'],
})
export class CoursesFormDialogComponent {
  public form: FormGroup<CourseForm>;
  public loading: boolean = false;
  public course: CourseDto | null = null;

  public get isEditing() {
    return !!this.course;
  }

  constructor(
    private _client: CoursesClient,
    private _dialogRef: MatDialogRef<CoursesFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: CoursesFormDialogData
  ) {
    this.course = data?.course ?? null;
    const nameInitValue = data?.course?.name ?? '';
    const descriptionInitValue = data?.course?.description ?? '';

    this.form = new FormGroup<CourseForm>({
      name: new FormControl(nameInitValue, {
        nonNullable: true,
        validators: [Validators.minLength(3), Validators.maxLength(30)],
      }),
      description: new FormControl(descriptionInitValue, { nonNullable: true }),
    });
  }

  public onFormSubmit() {
    if (this.form.invalid) {
      return;
    }

    this.save().subscribe({
      next: () => {
        this._dialogRef.close({ success: true });
      },
      complete: () => (this.loading = false),
    });
  }

  private save() {
    const { name, description } = this.form.value;

    return this.course
      ? this._client.editCourse(
          this.course.id!,
          new EditCourseDto({ name, description })
        )
      : this._client.addCourse(new AddCourseDto({ name, description }));
  }
}

interface CoursesFormDialogData {
  course: CourseDto;
}

interface CourseForm {
  name: FormControl<string>;
  description: FormControl<string>;
}

export interface CoursesFormDialogResult {
  success: boolean;
}