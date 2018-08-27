import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutModule } from './layout/layout.module';
import { LayoutComponent } from './layout/layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', loadChildren: './components/home/home.module#HomeModule' },
      { path: 'test', loadChildren: './components/test/test.module#TestModule' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes), LayoutModule],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
