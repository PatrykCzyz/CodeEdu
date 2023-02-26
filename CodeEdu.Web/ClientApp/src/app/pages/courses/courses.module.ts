import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';
import { CoursesListPageComponent } from './courses-list-page/courses-list-page.component';
import { CoursesListModule } from 'src/app/features/courses-list/courses-list.module';
import { CoursesAddDialogModule } from 'src/app/features/courses-add-dialog/courses-add-dialog.module';

@NgModule({
  declarations: [CoursesListPageComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{ path: '', component: CoursesListPageComponent }]),
    CoursesListModule,
    MatButtonModule,
    CoursesAddDialogModule,
    MatDialogModule
  ],
})
export class CoursesModule {}