import { Component, ViewContainerRef, ViewChild, OnInit } from '@angular/core';
import { ProductDataService } from '../service/product.data.Service';
import { IProduct } from '../shared/interfaces';
import { NotificationService } from '../utils/notification.service';

@Component({
  selector: 'billing-home',
  templateUrl: './billing.html'
})

export class BillingComponent implements OnInit{
  
  products:IProduct[];

  constructor(private productDataService: ProductDataService, private notificationService: NotificationService){}

  ngOnInit() {
  this.productDataService.getUsers()
            .subscribe((product: IProduct[]) => {
                this.products = product;
            },
            error => {
                this.notificationService.printErrorMessage('Failed to load users. ' + error);
            });
  }
  title = 'Billing';
  testModel = 'test data';
  // products = [
  //   { name: 'Manjal', price: 200.00, quantity: '500g', total: 100.00 },
  //   { name: 'Seeragam', price: 450.00, quantity: '250g', total: 112.50 },
  //   { name: 'Kadugu', price: 80.00, quantity: '250g', total: 20.00 },
  //   { name: 'Malli', price: 110.00, quantity: '1kg', total: 110.00 },
  //   { name: 'Poondu', price: 230.00, quantity: '500g', total: 115.00 },
  //   { name: 'Milagu', price: 850.00, quantity: '50g', total: 42.50 }
  // ];

  // total = this.products.reduce((acc, val) => acc + val.total, 0);
}
