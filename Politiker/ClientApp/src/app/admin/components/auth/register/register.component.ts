import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../../../../services/user.service';
import { UserRegistration } from '../../../../models/user';
import { FormStatus } from '../../../../enums/form-status';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  user: UserRegistration;
  created: boolean = false;
  hasServerErrors: boolean = false;
  submitted: boolean = false;
  serverErrors: string[];
  formStatusType = FormStatus;
  formStatus: FormStatus = FormStatus.Ready;
  public formErrors: object = {
    login: "Wprowadz login",
    password: 'Hasło powinno mieć conajmniej 8 liter',
    email: 'Wprowadz poprawny adres email'
  };

  constructor(private fb: FormBuilder, private userService: UserService, private router: Router) {
    this.registerForm = fb.group({
      Login: ['', Validators.required],
      Password: ['', [Validators.required, Validators.minLength(8)]],
      Email: ['', [Validators.required, Validators.email]]
    });


  }

  ngOnInit() {
  }

  onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }
    this.formStatus = FormStatus.Proccessing;

    this.user = {
      ...this.registerForm.value
    };

    this.userService.register(this.user)
      .subscribe(
      () => { this.formStatus = FormStatus.Succeed; this.hasServerErrors = false; this.router.navigateByUrl('/admin/auth/login', { queryParams: { login: this.user.Login, freshUser: true}})},
      (err) => { this.serverErrors = err; this.hasServerErrors = true; this.formStatus = FormStatus.Ready }
    )
    
  }
}
