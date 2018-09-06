import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WavesModule, CardsFreeModule } from 'angular-bootstrap-md';
import { SharedModule } from '../../../selectors/shared.module';
import { ButtonsModule } from 'angular-bootstrap-md';

import { TestRoutingModule } from './test-routing.module';
import { TestComponent } from './test.component';
import { StartComponent } from './start/start.component';
import { RegionService } from '../../../services/region.service';
import { SelectComponent } from '../../../selectors';
import { FormsModule } from '@angular/forms';
import { QuizComponent } from './quiz/quiz.component';
import { StepPersonalComponent } from './start/step-personal/step-personal.component';
import { ManageTestComponent } from './manage-test/manage-test.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    TestRoutingModule,
    WavesModule,
    CardsFreeModule,
    SharedModule,
    ButtonsModule
  ],
  providers: [
    RegionService
  ],
  declarations: [TestComponent, StartComponent, QuizComponent, StepPersonalComponent, ManageTestComponent]
})
export class TestModule { }
