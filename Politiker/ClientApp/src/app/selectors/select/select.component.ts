import { Component, OnInit, ElementRef, HostListener, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.scss'],
})
export class SelectComponent implements OnInit {
  clickedSelect: boolean = false;
  clickedOutside: boolean = false;
  @Input() options: any[];
  @Output() selectedOption = new EventEmitter<string>();
  selectedOptionView: any = null;
  constructor(private _eref: ElementRef) { }

  ngOnInit() {
  }

  @HostListener('document:click', ['$event'])
  clickout(event) {
    if (!this._eref.nativeElement.contains(event.target)) {
      this.clickedSelect = false;
    } 
  }

  manageOptionsView() {
    this.clickedSelect = !this.clickedSelect;
  }

  changeValue(value) {
    this.selectedOption.emit(value);
    this.selectedOptionView = value;
  }


}
