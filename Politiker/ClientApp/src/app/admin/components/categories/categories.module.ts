import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'

import { WavesModule, ButtonsModule, CardsFreeModule, InputsModule, IconsModule } from 'angular-bootstrap-md'

import { CategoriesRoutingModule } from './categories-routing.module';
import { AddCategoryComponent } from './add-category/add-category.component';

@NgModule({
  imports: [
    CommonModule,
    CategoriesRoutingModule,
    CardsFreeModule,
    ButtonsModule,
    WavesModule,
    InputsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [AddCategoryComponent]
})
export class CategoriesModule { }
