import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestComponent } from './test.component';
import { StartComponent } from './start/start.component';

const routes: Routes = [
  { path: '', component: TestComponent },
  { path: 'start', component: StartComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TestRoutingModule { }
