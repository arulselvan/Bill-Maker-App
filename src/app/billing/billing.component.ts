import { Component } from '@angular/core';
import { IProduct } from '../shared/interfaces';

@Component({
  selector: 'billing-home',
  templateUrl: './billing.component.html'
})

export class BillingComponent {
  products: IProduct[] = [];

  selectedItems(product: IProduct) {
    this.products.push(product);
  }

  title = 'Billing';
  testModel = 'test data';
}
