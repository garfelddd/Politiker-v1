import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WavesModule, CardsFreeModule } from 'angular-bootstrap-md';

import { TestRoutingModule } from './test-routing.module';
import { TestComponent } from './test.component';
import { StartComponent } from './start/start.component';

@NgModule({
  imports: [
    CommonModule,
    TestRoutingModule,
    WavesModule,
    CardsFreeModule
  ],
  declarations: [TestComponent, StartComponent]
})
export class TestModule { }
