import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { BookResponse } from '../models/book';
import { MyBooksResponse, ReservationViewResponse } from '../models/myBooks';
import { AuthenticationService } from './auth.service';
import { User } from '../models/user.model';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookByCodeService {
  baseUrl: string = 'https://localhost:44332/api/Reservation/'
  user: User | null
  rxSubscriptions: Subscription[] = [];
  
  constructor(private httpClient: HttpClient, private authenticationService : AuthenticationService) { }

  ngOnInit(): void {

  }

  BookByCode(Code:number) {
    this.user = this.authenticationService.Local()
    const route = `${this.baseUrl}BookByCode`
    const header = new HttpHeaders().set("Authorization", "Bearer " + this.user?.Token);
    return this.httpClient.post<ReservationViewResponse>(route, {code:Code}, {headers: header})
  }

  UpdateStatus(code: number, statusName: string) {
    this.user = this.authenticationService.Local()
    const route = `${this.baseUrl}StatusUpdate`
    const header = new HttpHeaders().set("Authorization", "Bearer " + this.user?.Token);
    return this.httpClient.post<ReservationViewResponse>(route, {reservationCode: code, status: statusName}, {headers: header})
  }


  ngOnDestroy(): void {
    this.rxSubscriptions.forEach(x => x.unsubscribe());
  }
}
