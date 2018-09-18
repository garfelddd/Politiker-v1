import { Directive, Input, ElementRef, Renderer, HostBinding, OnChanges, SimpleChanges } from '@angular/core';
import { FormStatus } from '../enums/form-status';

@Directive({
  selector: 'input[processingInput]'
})
export class OnProcessingInputDirective implements OnChanges {

  @Input('processingInput') formStatus: FormStatus;
  @HostBinding('disabled') disabled;
  formStatusType = FormStatus;
  constructor(private el: ElementRef, private renderer: Renderer) {

  }
  updateState() {
    if (this.formStatus === FormStatus.Proccessing)
      this.disabled = true;
    else
      this.disabled = false;
  }
  
  ngOnChanges(changes: SimpleChanges) {
    this.updateState();
  }

}
