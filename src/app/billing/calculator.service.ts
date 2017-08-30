import { Injectable } from '@angular/core';

@Injectable()
export class CalculatorService {
    constructor() { }

    currencyRoundOff(amout: number): number {
        return Math.round(amout * Math.pow(10, 2)) / Math.pow(10, 2);
    }

    calculateCgstAmount(item: any): number {
        var amout = item.Quantity * item.Price;
        return this.currencyRoundOff((item.Cgst * amout / 100));
    }

    calculateSgstAmount(item: any): number {
        var amout = item.Quantity * item.Price;
        return this.currencyRoundOff((item.Sgst * amout / 100));
    }

    calculateItemAmount(item: any) {
        var amout = this.currencyRoundOff(item.Quantity * item.Price);
        return this.currencyRoundOff(this.calculateCgstAmount(item) + this.calculateSgstAmount(item) + amout);
    }

    calculateItemWithOutTaxAmount(item: any) {
        var amout = this.currencyRoundOff(item.Quantity * item.Price);
        return amout;
    }
}
