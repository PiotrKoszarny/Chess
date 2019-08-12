import { Component, OnInit, ElementRef } from '@angular/core';
import { CounterMove } from './models/counterMove';
import { ChessService } from './services/chess.service';
import { FieldPosition } from './models/fieldPosition';
import { CounterEnum } from './models/counterEnum';
import { Observable } from 'rxjs';
import { Counter } from './models/counter';
import { map } from 'rxjs/operators';
import { Movement } from './movement';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Chess';
  leftPx = 0;
  topPx = 0;
  counters: Counter[];
  boardSquere = [0, 1, 2, 3, 4, 5, 6, 7];
  counter: Counter = {};

  constructor(
    private chessService: ChessService
  ) {
  }

  ngOnInit() {
    this.getCounters();
  }
  getCounters() {
    this.chessService.getCounters().subscribe(resp => {
      this.counters = resp;
    });
  }

  setStartPosition(newCounterPosition: FieldPosition) {
    this.counter.position = newCounterPosition;
    this.counter.isSelected = true;

    this.setCounterPosition(newCounterPosition.elementRef);
  }

  changecounters($event: { value: CounterEnum; }) {
    const selectedCounter = this.counters.filter(x => x.counter === $event.value)[0];
    this.counter.counter = selectedCounter.counter;
    this.counter.imgName = selectedCounter.imgName;
  }

  chageCounterPosition(newCounterPosition: FieldPosition) {

    if (this.counter.counter === undefined) {
      this.chessService.showMessage('Najpierw wybierz pionek');
      return;
    }

    if (this.counter.isSelected === undefined) {
      this.setStartPosition(newCounterPosition);
    } else {
      this.isValidMovement(newCounterPosition);
    }
  }

  isValidMovement(move: FieldPosition) {

    const movement: Movement = {
      startX: this.counter.position.positionX,
      startY: this.counter.position.positionY,
      endX: move.positionX,
      endY: move.positionY
    };
    const counterMove: CounterMove = {
      counter: this.counter.counter,
      move: movement
    };

    this.chessService.isValidMovement(counterMove).subscribe(resp => {
      if (resp) {
        this.counter.position = move;
        this.setCounterPosition(move.elementRef);
      } else {
        this.chessService.showMessage('Ruch dla wybranej figury jest niedozwolony');
      }
    });
  }

  setCounterPosition(elementRef: ElementRef) {
    this.leftPx = elementRef.nativeElement.offsetLeft;
    this.topPx = elementRef.nativeElement.offsetTop;
  }
}
