import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DashboardModule } from './components/dashboard/dashboard.module';
import { LayoutModule } from './layout/layout.module';


const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'auth',
        loadChildren: './components/auth/auth.module#AuthModule'
      },
      {
        path: '',
        component: LayoutComponent,
        children: [
          { path: 'dashboard', component: DashboardComponent },
          { path: 'category', loadChildren: './components/categories/categories.module#CategoriesModule', data: {title: 'Kategoria'}}
        ]
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    LayoutModule,
    DashboardModule
  ],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
