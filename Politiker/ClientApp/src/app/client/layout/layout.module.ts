import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { LayoutComponent } from './layout.component';
import { HeaderComponent } from './header/header.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MDBBootstrapModule.forRoot(),
  ],
  declarations: [LayoutComponent, HeaderComponent],
  exports: [
    LayoutComponent
  ]
})
export class LayoutModule { }
