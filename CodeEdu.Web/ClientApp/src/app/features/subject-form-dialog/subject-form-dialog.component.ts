import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {
  AddSubjectDto,
  CourseDto,
  CoursesClient,
  EditSubjectDto,
  SubjectDto,
} from 'src/app/api/client';

@Component({
  selector: 'app-subject-form-dialog',
  templateUrl: './subject-form-dialog.component.html',
  styleUrls: ['./subject-form-dialog.component.scss'],
})
export class SubjectAddDialogComponent {
  public form: FormGroup<AddSubjectForm>;
  public loading: boolean = false;
  public course: CourseDto;
  public subject: SubjectDto | null;

  public get isEditing() {
    return !!this.subject;
  }

  constructor(
    private _client: CoursesClient,
    private _dialogRef: MatDialogRef<SubjectAddDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: SubjectAddDialogData
  ) {
    this.course = data.course;
    this.subject = data.subject ?? null;

    const nameInitValue = this.subject?.name ?? '';

    this.form = new FormGroup<AddSubjectForm>({
      name: new FormControl(nameInitValue, {
        nonNullable: true,
        validators: [Validators.minLength(3), Validators.maxLength(40)],
      }),
    });
  }

  public onSubmit() {
    if (this.form.invalid || !this.form.value.name) {
      return;
    }

    const { name } = this.form.value;

    this._execute(name).subscribe({
      next: () => {
        this._dialogRef.close();
      },
      complete: () => (this.loading = false),
    });
  }

  private _execute(name: string) {
    return this.subject
      ? this._client.editSubject(
          this.course.id!,
          this.subject.id!,
          new EditSubjectDto({ name })
        )
      : this._client.addSubjectToCourse(
          this.course.id!,
          new AddSubjectDto({ name })
        );
  }
}

interface AddSubjectForm {
  name: FormControl<string>;
}

interface SubjectAddDialogData {
  course: CourseDto;
  subject: SubjectDto;
}
