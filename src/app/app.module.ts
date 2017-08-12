import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Ng2CompleterModule } from 'ng2-completer';
import { FormsModule } from "@angular/forms";

import { AppComponent } from './app.component';
import { BillingComponent } from './billing/billing';
import { SearchComponent } from './billing/billing.search';

@NgModule({
  declarations: [    AppComponent,
  BillingComponent,
    SearchComponent  ],
  imports: [
    BrowserModule,
    Ng2CompleterModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
