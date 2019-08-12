import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CounterMove } from '../models/counterMove';
import { Observable } from 'rxjs';
import { Counter } from '../models/counter';
import { MatDialog } from '@angular/material';
import { MessageComponent } from '../message/message.component';

@Injectable({
  providedIn: 'root'
})
export class ChessService {
  private chessUrl = `${environment.apiUrl}chess`;
  constructor(
    private http: HttpClient,
    private dialog: MatDialog
  ) { }

  isValidMovement(counterMove: CounterMove): Observable<boolean> {
    return this.http.post<boolean>(this.chessUrl, counterMove);
  }

  getCounters(): Observable<Counter[]> {
    return this.http.get<Counter[]>(this.chessUrl);
  }

  showMessage(message: string) {
    this.dialog.open(MessageComponent, {
      data: message
    });
  }
}
