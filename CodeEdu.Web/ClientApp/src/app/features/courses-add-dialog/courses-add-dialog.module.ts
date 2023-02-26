import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { CoursesAddDialogComponent } from './courses-add-dialog.component';

@NgModule({
  declarations: [CoursesAddDialogComponent],
  imports: [
    CommonModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    ReactiveFormsModule,
  ],
  exports: [CoursesAddDialogComponent],
})
export class CoursesAddDialogModule {}
