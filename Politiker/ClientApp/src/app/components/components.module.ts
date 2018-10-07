import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule, TooltipModule, PopoverModule, ButtonsModule } from 'angular-bootstrap-md'
import { ModalElementComponent } from './modal-element/modal-element.component';

@NgModule({
  imports: [
    CommonModule,
    ModalModule.forRoot(),
    TooltipModule,
    PopoverModule,
    ButtonsModule
  ],
  declarations: [ModalElementComponent],
  exports: [
    ModalElementComponent
  ],
  entryComponents: [ModalElementComponent]
})
export class ComponentsModule { }
