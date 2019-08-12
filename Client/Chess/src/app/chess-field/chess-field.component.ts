import { Component, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { FieldPosition } from '../models/fieldPosition';

@Component({
  selector: 'app-chess-field',
  templateUrl: './chess-field.component.html',
  styleUrls: ['./chess-field.component.scss']
})
export class ChessFieldComponent {
  @Input() isWhiteColor: boolean;
  @Input() set row(row: number) {
    this.fieldPostion.positionX = row;
  }
  @Input() set column(column: number) {
    this.fieldPostion.positionY = column;
  }

  @Output() counterPosition = new EventEmitter<FieldPosition>();

  private fieldPostion: FieldPosition;

  constructor(
    private elRef: ElementRef
  ) {
    this.fieldPostion = {
      elementRef: elRef
    };
  }

  setCounterPosition() {
    this.counterPosition.emit(this.fieldPostion);
  }
}
