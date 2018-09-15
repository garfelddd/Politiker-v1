import { Directive, Input, ElementRef, Renderer, HostBinding, OnChanges, SimpleChanges } from '@angular/core';
import { FormStatus } from '../enums/form-status';

@Directive({
  selector: 'input[processingInput]'
})
export class OnProcessingInputDirective implements OnChanges {

  @Input('processingInput') conditional: boolean = false;
  @HostBinding('disabled') disabled;
  formStatusType = FormStatus;
  constructor(private el: ElementRef, private renderer: Renderer) {

  }
  updateState() {
    this.disabled = this.conditional;
  }
  
  ngOnChanges(changes: SimpleChanges) {
    this.updateState();
  }

}
