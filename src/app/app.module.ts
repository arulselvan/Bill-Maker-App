import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Ng2CompleterModule } from 'ng2-completer';
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { BillingComponent } from './billing/billing.component';
import { SearchComponent } from './billing/billing.search';
import { ProductDataService } from './product/product.data.service';
import { ConfigService } from './utils/config.service';
import { NotificationService } from './utils/notification.service';

@NgModule({
  declarations: [
    AppComponent,
    BillingComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule,
    Ng2CompleterModule,
    FormsModule
  ],
  providers: [ProductDataService, ConfigService, NotificationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
