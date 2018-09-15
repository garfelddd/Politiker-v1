import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { UserAuth } from '../../../../models/user-auth';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  private loginForm: FormGroup;
  private subscription: Subscription;
  private credentials: UserAuth = { Login: '', Password: '' };
  freshUser: boolean = false;

  hasServerErrors: boolean;
  serverErrors: string[] = [];
  public formErrors: object = {
    login: "Wprowadz login",
    password: 'Wprowadz haslo'
  };

  constructor(private fb: FormBuilder, private activatedRoute: ActivatedRoute) {
  }

  ngOnInit() {
    this.loginForm = this.fb.group({
      Login: [this.credentials.Login, Validators.required],
      Password: ['', Validators.required]
    });

    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.freshUser = param['frashUser'];
        this.credentials.Login = param['login'];
      });   
  }

}
