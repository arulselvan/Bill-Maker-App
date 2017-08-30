import { Component } from '@angular/core';
import { DataTableResource } from 'angular-2-data-table';
import { ProductDataService } from '../product/product.data.service';
import { NotificationService } from '../utils/notification.service';
import { IProduct } from '../shared/interfaces';

@Component({
  selector: 'product-details',
  providers: [],
  templateUrl: 'product.grid.directive.html',
  styleUrls: ['product.component.css'
  ]
})
export class ProductComponent {

  itemResource:DataTableResource<IProduct>;

  items = [];
  itemCount = 0;

  constructor(private productDataService: ProductDataService,
    private notificationService: NotificationService) {
    this.productDataService.getProducts()
      .subscribe((product: IProduct[]) => {
        this.itemResource = new DataTableResource(product);
        this.itemResource.count().then(count => this.itemCount = count);
      },
      error => {
        this.notificationService.printErrorMessage('Failed to load users. ' + error);
      });
      
  }
  reloadItems(params) {
    this.productDataService.getProducts()
    .subscribe((product: IProduct[]) => {
      this.itemResource = new DataTableResource(product);
    this.itemResource.query(params).then(items => this.items = items);
  },
    error => {
      this.notificationService.printErrorMessage('Failed to load users. ' + error);
    });
  }

  // special properties:

  rowClick(rowEvent) {
    console.log('Clicked: ' + rowEvent.row.item.name);
  }

  rowDoubleClick(rowEvent) {
    alert('Double clicked: ' + rowEvent.row.item.name);
  }

  rowTooltip(item) { return item.jobTitle; }
}