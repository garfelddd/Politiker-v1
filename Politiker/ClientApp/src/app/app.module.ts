import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { RegionService } from './services/region.service';
import { ClickOutsideDirective } from './directives/click-outside.directive';


@NgModule({
  declarations: [
    AppComponent,
    ClickOutsideDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [RegionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
