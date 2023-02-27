import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { ChangeSubjectsOrderDialogComponent } from './change-subjects-order-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [
    ChangeSubjectsOrderDialogComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule,
    DragDropModule
  ],
  exports: [
    ChangeSubjectsOrderDialogComponent
  ]
})
export class ChangeSubjectsOrderDialogModule { }
