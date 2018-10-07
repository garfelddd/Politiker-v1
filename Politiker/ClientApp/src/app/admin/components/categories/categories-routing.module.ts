import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCategoryComponent } from './add-category/add-category.component';
import { ListCategoriesComponent } from './list-categories/list-categories.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';

const routes: Routes = [
  { path: '', component: ListCategoriesComponent, data: { title: 'Lista' } },
  { path: 'add', component: AddCategoryComponent, data: { title: 'Dodawanie' } },
  { path: 'edit', component: EditCategoryComponent, data: { title: 'Edytowanie'} }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
