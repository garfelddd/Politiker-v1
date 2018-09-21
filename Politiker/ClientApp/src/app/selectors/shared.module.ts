import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectComponent } from './select/select.component';
import { NavItemComponent } from './nav-item/nav-item.component';
import { NavItemHeadComponent } from './nav-item/nav-item-head.component';
import { NavItemBodyComponent } from './nav-item/nav-item-body.component';


@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [
    SelectComponent,
    NavItemComponent,
    NavItemHeadComponent,
    NavItemBodyComponent
  ],
  exports: [
    SelectComponent,
    NavItemComponent,
    NavItemHeadComponent,
    NavItemBodyComponent
  ]
})
export class SharedModule { }
