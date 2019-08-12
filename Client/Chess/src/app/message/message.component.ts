import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss']
})
export class MessageComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public message: string,
    public dialogRef: MatDialogRef<MessageComponent>
  ) {
  }
  closeDialog() {
    this.dialogRef.close();
  }
}
