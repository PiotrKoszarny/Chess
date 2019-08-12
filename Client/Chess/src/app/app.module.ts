import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MatRadioModule, MatDialogModule, MatButtonModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ChessFieldComponent } from './chess-field/chess-field.component';
import { HttpClientModule } from '@angular/common/http';
import { MessageComponent } from './message/message.component';

@NgModule({
  declarations: [
    AppComponent,
    ChessFieldComponent,
    MessageComponent
  ],
  imports: [
    BrowserModule,
    MatRadioModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [MessageComponent]
})
export class AppModule { }
