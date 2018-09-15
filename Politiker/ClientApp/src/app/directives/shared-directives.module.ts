import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OnProcessingInputDirective } from './on-processing-input.directive';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    OnProcessingInputDirective
  ],
  declarations: [OnProcessingInputDirective]
})
export class SharedDirectivesModule { }
