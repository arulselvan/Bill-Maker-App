import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Ng2CompleterModule } from 'ng2-completer';
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { BillingComponent } from './billing/billing.component';
import { ProductComponent } from './product/product.component';
import { SearchComponent } from './billing/billing.search';
import { ProductDataService } from './product/product.data.service';
import { ConfigService } from './utils/config.service';
import { NotificationService } from './utils/notification.service';
import { FocusDirective } from './utils/focus.directive';
import { ExportDirective } from './utils/export.directive';
import { CalculatorService } from './billing/calculator.service';
import { RouterModule, Routes } from '@angular/router';
import { DataTableModule } from 'angular-2-data-table';


const appRoutes: Routes = [
  { path: '', component: BillingComponent },
  { path: 'Billing', component: BillingComponent },
  { path: 'Product', component: ProductComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    BillingComponent,
    ProductComponent,
    SearchComponent,
    FocusDirective,
    ExportDirective 
  ],
  imports: [    
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    Ng2CompleterModule,
    FormsModule,
    DataTableModule
  ],
  providers: [ProductDataService, ConfigService, NotificationService, CalculatorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
