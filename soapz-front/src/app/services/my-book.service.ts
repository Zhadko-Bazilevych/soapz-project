import { Injectable, OnChanges, OnInit } from '@angular/core';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { BookResponse } from '../models/book';
import { MyBooksResponse } from '../models/myBooks';
import { AuthenticationService } from './auth.service';
import { User } from '../models/user.model';
import { Subscription } from 'rxjs';
import { BaseResponse } from '../models/baseResponse';

@Injectable({
  providedIn: 'root'
})
export class MyBookService {
  baseUrl: string = 'https://localhost:44332/api/Content/'
  user: User | null;
  rxSubscriptions: Subscription[] = [];

  constructor(private httpClient: HttpClient, private authenticationService : AuthenticationService) { }

  MyBooks(){
    this.user = this.authenticationService.Local()

    const route = `${this.baseUrl}MyBooks`
    const header = new HttpHeaders().set("Authorization", "Bearer " + this.user?.Token);
    return this.httpClient.post<MyBooksResponse>(route, {id:this.user?.Id}, {headers: header})
  }

  BookInfo(id: number){
    const route = `${this.baseUrl}Books/${id}`

    let params = new HttpParams().set('id', id);
    return this.httpClient.get<BookResponse>(route, {params: params})
  }

  Reservate(id: number){
    this.user = this.authenticationService.Local()
    const request = { 
      userId: this.user?.Id,
      bookId: id,
      reservationCode: Math.floor(1000000 + Math.random() * 9000000)
    }

    const route = `https://localhost:44332/api/Reservation/Reservate`
    const header = new HttpHeaders().set("Authorization", "Bearer " + this.user?.Token);
    return this.httpClient.post<BaseResponse>(route, request, {headers: header})
  }
}
