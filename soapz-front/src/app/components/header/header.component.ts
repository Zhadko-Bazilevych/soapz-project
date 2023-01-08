import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isAuth: boolean
  isLibrarian: boolean

  user: User | null;

  rxSubscriptions: Subscription[] = [];

  constructor(private authenticationService : AuthenticationService, private router : Router) { }

  ngOnInit(): void {
    const sub = this.authenticationService.user$.subscribe(user => {
      this.user = user;
      if(user?.Id!=null) this.isAuth=true;
      if(user?.Role=="Librarian") this.isLibrarian = true;
    });
    this.rxSubscriptions.push(sub);
  }

  logout(){
    this.authenticationService.logout();
    this.isAuth = false;
    this.isLibrarian = false;
    this.router.navigate(['/Home'])
  }
  
  ngOnDestroy(): void {
    this.rxSubscriptions.forEach(x => x.unsubscribe());
  }

  login(){
    this.router.navigate(['/Login'])
  }
  register(){
    this.router.navigate(['/Register'])
  }

}
