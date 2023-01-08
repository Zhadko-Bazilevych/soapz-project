import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { BaseResponse } from 'src/app/models/baseResponse';
import { AuthenticationService } from 'src/app/services/auth.service';
import { hasLowerCase, hasNumeric, hasUpperCase, isphone, matchValidator } from 'src/shared/validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  register = new FormGroup({
    email: new FormControl('', [Validators.email, Validators.required]),
    phone: new FormControl('', [Validators.required, isphone()]),
    password: new FormControl('', [Validators.required, Validators.minLength(6), hasLowerCase(), hasUpperCase(), hasNumeric()]),
    confirmPassword: new FormControl('', [Validators.required, matchValidator('password')])
  })
  get email() { return this.register.get('email') }
  get password() { return this.register.get('password') }
  get confirmPassword() { return this.register.get('confirmPassword') }
  get phone() { return this.register.get('phone') }
  submited: boolean = false;
  error: string | null | undefined= null;

  constructor(private authenticationService: AuthenticationService, private router: Router) { }

  ngOnInit() {

  }

  async Register() {
    this.submited = true;
    if (this.register.valid) {
      if (!!this.email && !!this.password && !!this.confirmPassword && !!this.phone && !!this.email.value && !!this.password.value && !!this.confirmPassword.value && !!this.phone.value ) {
        this.error = undefined;
        const response = await firstValueFrom(this.authenticationService.Register(this.email.value, this.password.value, this.confirmPassword.value, this.phone.value))
          .catch(y => { this.error = y.error });
        if (response.code != 200) {
          this.error = response.message
        }
        if (!this.error) {
          const response = await firstValueFrom(this.authenticationService.Login(this.email.value, this.password.value, true))
          this.router.navigate(["/Home"])
        }
      }
    }
  }

  loginForm() {
    this.router.navigate(['/Login'])
  }
  registerForm() {

  }
}
