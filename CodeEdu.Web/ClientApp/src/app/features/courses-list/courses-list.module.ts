import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CoursesListComponent } from './courses-list.component';
import { CoursesClient } from 'src/app/api/client';
import { ConfirmationDialogModule } from '../confirmation-dialog/confirmation-dialog.module';
import { CourseCardComponent } from './course-card/course-card.component';
import { SubjectAddDialogModule } from '../subject-add-dialog/subject-add-dialog.module';

@NgModule({
  declarations: [CoursesListComponent, CourseCardComponent],
  imports: [
    CommonModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    ConfirmationDialogModule,
    SubjectAddDialogModule,
    MatProgressSpinnerModule,
  ],
  exports: [CoursesListComponent],
  providers: [CoursesClient],
})
export class CoursesListModule {}
