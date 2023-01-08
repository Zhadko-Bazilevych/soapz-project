import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { AuthenticationService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  submited: boolean = false;
  login = new FormGroup({
    email: new FormControl('', [Validators.email, Validators.required]),
    password: new FormControl('', Validators.required),
    rememberMe: new FormControl<boolean>(true),
  })
  
  get email() { return this.login.get('email') }
  get password() { return this.login.get('password') }
  get rememberMe() { return this.login.get('rememberMe') }
  error !: string | null

  constructor(private authenticationService: AuthenticationService, private router : Router) { }

  ngOnInit() {

  }


  async Login() {
    this.submited = true;
    if (this.login.valid) {
      this.error = null;
      if (!!this.email && !!this.password && !!this.email.value && !!this.password.value) {

        const response = await firstValueFrom(this.authenticationService.Login(this.email.value, this.password.value, this.rememberMe!.value ?? false))
          .catch(y => { this.error = y.error });
        if (response.code != 200) {
          this.error = response.message
        }
        
        if (!this.error) {
          this.router.navigate(['/Home'])
        }
      }
    }
  }


  loginForm() {
    
  }
  registerForm() {
    this.router.navigate(['/Register'])
  }
}
