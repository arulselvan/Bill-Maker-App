import { Component, EventEmitter, AfterViewChecked, ElementRef, ViewChild, OnInit } from '@angular/core';
import { IProduct, IUnit } from '../shared/interfaces';
import { CalculatorService } from '../billing/calculator.service';

@Component({
  selector: 'billing-home',
  templateUrl: './billing.component.html',
  styleUrls: ['../app.component.css', './billing.component.css'],
  providers: [CalculatorService]
})

export class BillingComponent implements OnInit, AfterViewChecked {

  constructor(private calculatorService: CalculatorService) { }

  @ViewChild('scrollMe') private myScrollContainer: ElementRef;

  public myFocusTriggeringEventEmitter = new EventEmitter<boolean>();
  public exportTriggeringEventEmitter = new EventEmitter<boolean>();

  product: IProduct;
  billItems: IProduct[];
  billnumber:string;
  ngOnInit() {
    this.scrollToBottom();
    this.product = { Unit: {} } as any;
    this.billItems = [];
  }

  ngAfterViewChecked() {
    this.scrollToBottom();
  }

  scrollToBottom(): void {
    try {
      this.myScrollContainer.nativeElement.scrollTop = this.myScrollContainer.nativeElement.scrollHeight;
    } catch (err) { }
  }

  public totalWithOutTax: number = 0;
  public totalCgst: number = 0;
  public totalSgst: number = 0;

  selectedItems(product: IProduct) {
    this.product = Object.assign({}, product);
    this.myFocusTriggeringEventEmitter.emit(true);
  }

  addItemToBill() {
    if (this.product['Price'] === undefined) {
      return;
    }
    this.billItems.push(Object.assign({}, this.product));
    this.calculateTotal();
    this.product = { Unit: {} } as any;
  }

  removeBillItem(item: IProduct) {
    let index: number = this.billItems.indexOf(item);
    if (index !== -1) {
      this.billItems.splice(index, 1);
      this.calculateTotal();
    }
  }

  printBill() { }
  saveBill() {
    this.exportTriggeringEventEmitter.emit(true);
  }
  cancelBill() {
    this.billItems = [];
    this.calculateTotal();
  }

  public twoHalfCgstAmount: number = 0;
  public twoHalfCgstTax: number = 0;
  public twoHalfSgstAmount: number = 0;
  public twoHalfSgstTax: number = 0;

  public sixCgstAmount: number = 0;
  public sixCgstTax: number = 0;
  public sixSgstAmount: number = 0;
  public sixSgstTax: number = 0;

  public nineCgstAmount: number = 0;
  public nineCgstTax: number = 0;
  public nineSgstAmount: number = 0;
  public nineSgstTax: number = 0;

  public fourteenCgstAmount: number = 0;
  public fourteenCgstTax: number = 0;
  public fourteenSgstAmount: number = 0;
  public fourteenSgstTax: number = 0;

  calculateTotal() {
    var totalWithOutTax: number = 0;
    var totalCgstAmount: number = 0;
    var totalSgstAmount: number = 0;
    this.billItems.forEach(item => {
      var amout = this.calculatorService.calculateItemWithOutTaxAmount(item);
      var cgstAmount = this.calculatorService.calculateCgstAmount(item);
      var sgstAmount = this.calculatorService.calculateSgstAmount(item);
      totalCgstAmount += cgstAmount;
      totalSgstAmount += sgstAmount
      totalWithOutTax += amout;
      if (item['Cgst'] === 2.5) {
        this.twoHalfCgstAmount += amout;
        this.twoHalfCgstTax += cgstAmount;
        this.twoHalfSgstAmount += amout;
        this.twoHalfSgstTax += sgstAmount;
      } else if (item['Cgst'] === 6) {
        this.sixCgstAmount += amout;
        this.sixCgstTax += cgstAmount;
        this.sixSgstAmount += amout;
        this.sixSgstTax += sgstAmount;
      }else if (item['Cgst'] === 9) {
        this.nineCgstAmount += amout;
        this.nineCgstTax += cgstAmount;
        this.nineSgstAmount += amout;
        this.nineSgstTax += sgstAmount;
      }else if (item['Cgst'] === 14) {
        this.fourteenCgstAmount += amout;
        this.fourteenCgstTax += cgstAmount;
        this.fourteenSgstAmount += amout;
        this.fourteenSgstTax += sgstAmount;
      }
    });
    this.totalWithOutTax = this.calculatorService.currencyRoundOff(totalWithOutTax);
    this.totalCgst = this.calculatorService.currencyRoundOff(totalCgstAmount);
    this.totalSgst = this.calculatorService.currencyRoundOff(totalSgstAmount);
  }
}
