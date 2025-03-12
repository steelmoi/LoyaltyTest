import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SessionService } from '../../../services/session.service';
import { Users } from '../../../Models/users';
import { AlertService } from '../../../services/alert.service';
import { UsersService } from '../../../services/users.service';
import { UserRequest } from '../../../Models/Api/user-request';
import { ApiResultLogin } from '../../../Models/Api/api-result-login';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
    user: Users = new Users();
    submitted: boolean = false;

    loginForm: FormGroup = new FormGroup({
        userCode: new FormControl(''),
        pass: new FormControl('')
    });

    constructor(

        private formBuilder: FormBuilder,
        private route: Router,
        //private UserService: UserService,
        private sessionService: SessionService,
        private alertService: AlertService,
        private userService: UsersService
    ) { }

    ngOnInit(): void {
        let userLogged = this.sessionService.GetSession();
        //userLogged.id = 1
        if (userLogged.id > 0)
            this.gotoStores();

        this.loginForm = this.formBuilder.group(
            {
                userCode: ['', Validators.required],
                pass: ['', Validators.required]
            });
    }

    gotoStores(): void {
        this.route.navigateByUrl('/store-list');
    }

    get f(): { [key: string]: AbstractControl; } {
        return this.loginForm.controls;
    }

    onLogin() {
        this.submitted = true;
        let user = new UserRequest();
        user.Password = this.user.pass;
        user.UserCode = this.user.userCode;

        if (!this.loginForm.invalid) {
            this.userService.Login(user)
                .subscribe({
                    next: (user: ApiResultLogin) => {
                    if (user.status == 200) {
                          this.user.id = Number(user.data?.id)
                          this.user.customerId = Number(user.data?.customerId) | 0;
                          this.user.userName = String(user.data?.userName)
                          this.user.userLastName = String(user.data?.userLastName)
                          this.sessionService.CreateSession(this.user);
                          this.gotoStores()
                        } else {
                            this.alertService.ShowError(user.message);
                        }
                    }
                });
        }
    }
}
