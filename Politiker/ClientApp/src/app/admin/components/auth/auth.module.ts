import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputsModule, WavesModule, ButtonsModule, CardsFreeModule } from 'angular-bootstrap-md'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { AuthComponent } from './auth.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    InputsModule,
    WavesModule,
    ButtonsModule,
    CardsFreeModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [LoginComponent, AuthComponent, RegisterComponent]
})
export class AuthModule { }
