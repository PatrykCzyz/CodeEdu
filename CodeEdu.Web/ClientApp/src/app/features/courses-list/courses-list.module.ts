import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CoursesListComponent } from './courses-list.component';
import { CoursesClient } from 'src/app/api/client';

@NgModule({
  declarations: [CoursesListComponent],
  imports: [CommonModule, MatGridListModule, MatCardModule, MatButtonModule],
  exports: [CoursesListComponent],
  providers: [CoursesClient],
})
export class CoursesListModule {}
