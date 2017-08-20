import { Component, Input, Output, EventEmitter, DoCheck,OnChanges } from '@angular/core';
import { CompleterService, CompleterData, CompleterItem } from 'ng2-completer';

@Component({
  selector: 'text-search',
  template: `<ng2-completer (selected)="onSelected($event)" [inputClass]="'form-control'" [placeholder]="'search'" [dataService]="dataService" [minSearchLength]="0"></ng2-completer>
  `
})
export class SearchComponent implements OnChanges {
  ngOnChanges(): void {
    
  }

  @Input() rating: number;
    starWidth: number;
    @Output() ratingClicked: EventEmitter<string> =
        new EventEmitter<string>();

  public searchStr: string;
  private dataService: CompleterData;
  private searchData = [
    { color: 'red', value: '#f00' },
    { color: 'green', value: '#0f0' },
    { color: 'blue', value: '#00f' },
    { color: 'cyan', value: '#0ff' },
    { color: 'magenta', value: '#f0f' },
    { color: 'yellow', value: '#ff0' },
    { color: 'black', value: '#000' }
  ];

  constructor(private completerService: CompleterService) {
    this.dataService = completerService.local(this.searchData, 'color', 'color');
  }
  protected onSelected(item: CompleterItem) {
    console.log(item);
  }
}