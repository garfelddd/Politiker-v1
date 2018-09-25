import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { HeaderComponent } from './header/header.component';
import { NavbarModule, WavesModule, ButtonsModule } from 'angular-bootstrap-md'
import { RouterModule } from '@angular/router';
import { SidebarComponent } from './sidebar/sidebar.component';
import { SharedModule } from '../../selectors/shared.module';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NavbarModule,
    WavesModule,
    ButtonsModule,
    SharedModule
  ],
  exports: [LayoutComponent],
  declarations: [LayoutComponent, HeaderComponent, SidebarComponent, BreadcrumbComponent]
})
export class LayoutModule { }
