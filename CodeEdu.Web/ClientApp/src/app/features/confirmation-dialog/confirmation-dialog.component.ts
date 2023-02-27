import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css'],
})
export class ConfirmationDialogComponent implements OnInit {
  public title: string = 'Czy jesteś pewien, że chcesz to zrobić?';
  public content?: string;
  public confirmText: string = 'Potwierdź';
  public discardText: string = 'Anuluj';

  constructor(@Inject(MAT_DIALOG_DATA) data: ConfirmationDialogData) {
    if (data) {
      const { title, content, confirmText, discardText } = data;
      title && (this.title = title);
      content && (this.content = content);
      confirmText && (this.confirmText = confirmText);
      discardText && (this.discardText = discardText);
    }
  }

  ngOnInit(): void {}
}

export interface ConfirmationDialogData {
  title?: string;
  content?: string;
  confirmText?: string;
  discardText?: string;
}
