import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuestionsRoutingModule } from './questions-routing.module';
import { AddQuestionComponent } from './add-question/add-question.component';
import { CardsFreeModule, ButtonsModule, WavesModule, InputsModule } from 'angular-bootstrap-md';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedDirectivesModule } from '../../../directives/shared-directives.module';
import { ComponentsModule } from '../../../components/components.module';

@NgModule({
  imports: [
    CommonModule,
    QuestionsRoutingModule,
    CardsFreeModule,
    ButtonsModule,
    WavesModule,
    InputsModule,
    FormsModule,
    ReactiveFormsModule,
    SharedDirectivesModule,
    ComponentsModule
  ],
  declarations: [AddQuestionComponent]
})
export class QuestionsModule { }
