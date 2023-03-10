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
import { SubjectFormDialogModule } from '../subject-form-dialog/subject-form-dialog.module';
import { ChangeSubjectsOrderDialogModule } from '../change-subjects-order-dialog/change-subjects-order-dialog.module';

@NgModule({
  declarations: [CoursesListComponent, CourseCardComponent],
  imports: [
    CommonModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatProgressSpinnerModule,
    ConfirmationDialogModule,
    SubjectFormDialogModule,
    ChangeSubjectsOrderDialogModule,
  ],
  exports: [CoursesListComponent],
  providers: [CoursesClient],
})
export class CoursesListModule {}
