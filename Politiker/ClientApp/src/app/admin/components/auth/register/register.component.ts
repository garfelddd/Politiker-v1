import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../../../../services/user.service';
import { User } from '../../../../models/user';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  user: User;
  created: boolean = false;
  hasServerErrors: boolean = false;
  serverErrors: string[];
  public formErrors: object = {
    login: "Wprowadz login",
    password: 'Hasło powinno mieć conajmniej 8 liter',
    email: 'Wprowadz poprawny adres email'
  };

  constructor(private fb: FormBuilder, private userService: UserService) {
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
    this.user = {
      ...this.registerForm.value
    }

    this.userService.register(this.user)
      .subscribe(
      () => { this.created = true; this.hasServerErrors = false},
      (err) => { this.serverErrors = err; this.hasServerErrors = true; console.log(this.serverErrors);}
    )
    
  }
}
