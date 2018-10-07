import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'

import { WavesModule, ButtonsModule, CardsFreeModule, InputsModule, IconsModule } from 'angular-bootstrap-md'

import { CategoriesRoutingModule } from './categories-routing.module';
import { AddCategoryComponent } from './add-category/add-category.component';
import { SharedDirectivesModule } from '../../../directives/shared-directives.module';
import { ListCategoriesComponent } from './list-categories/list-categories.component';
import { ModalElementComponent } from '../../../components/modal-element/modal-element.component';
import { ComponentsModule } from '../../../components/components.module';
import { ModalComponentFactory } from '../../../factories/modal-component-factory';
import { ViewCategoryComponent } from './view-category/view-category.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';

@NgModule({
  imports: [
    CommonModule,
    CategoriesRoutingModule,
    CardsFreeModule,
    ButtonsModule,
    WavesModule,
    InputsModule,
    FormsModule,
    ReactiveFormsModule,
    SharedDirectivesModule,
    ComponentsModule
  ],
  entryComponents: [
    ModalElementComponent
  ],
  declarations: [AddCategoryComponent, ListCategoriesComponent, ViewCategoryComponent, EditCategoryComponent],
})
export class CategoriesModule { }
