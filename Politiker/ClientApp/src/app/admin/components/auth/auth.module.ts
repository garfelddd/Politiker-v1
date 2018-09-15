import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputsModule, WavesModule, ButtonsModule, CardsFreeModule } from 'angular-bootstrap-md'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { AuthComponent } from './auth.component';
import { RegisterComponent } from './register/register.component';
import { SharedDirectivesModule } from '../../../directives/shared-directives.module';

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    InputsModule,
    WavesModule,
    ButtonsModule,
    CardsFreeModule,
    FormsModule,
    ReactiveFormsModule,
    SharedDirectivesModule
  ],
  declarations: [LoginComponent, AuthComponent, RegisterComponent]
})
export class AuthModule { }
