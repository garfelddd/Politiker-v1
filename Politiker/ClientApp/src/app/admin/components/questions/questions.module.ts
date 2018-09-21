import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuestionsRoutingModule } from './questions-routing.module';
import { AddQuestionComponent } from './add-question/add-question.component';

@NgModule({
  imports: [
    CommonModule,
    QuestionsRoutingModule
  ],
  declarations: [AddQuestionComponent]
})
export class QuestionsModule { }
