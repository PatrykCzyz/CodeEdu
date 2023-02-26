import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { SubjectAddDialogComponent } from './subject-add-dialog.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [SubjectAddDialogComponent],
  imports: [
    CommonModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    ReactiveFormsModule
  ],
  exports: [SubjectAddDialogComponent],
})
export class SubjectAddDialogModule {}
