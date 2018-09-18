import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { UserAuth } from '../../../../models/user-auth';
import { UserService } from '../../../../services/user.service';
import { FormStatus } from '../../../../enums/form-status';


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
  formStatusType = FormStatus;
  formStatus: FormStatus = FormStatus.Ready;
  public formErrors: object = {
    login: "Wprowadz login",
    password: 'Wprowadz haslo'
  };

  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute, private userService: UserService) {
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

  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }
    this.formStatus = FormStatus.Proccessing;

    this.credentials = {
      ...this.loginForm.value
    };

    this.userService.login(this.credentials)
      .subscribe(
        () => {
          this.formStatus = FormStatus.Succeed;
          this.hasServerErrors = false;
          this.router.navigateByUrl('/');
        },
        (err) => {
          this.serverErrors = err;
          this.hasServerErrors = true;
          this.formStatus = FormStatus.Ready
        }
      )
  }

}
