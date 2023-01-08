import { Injectable } from '@angular/core';
import { BooklistRequest, BooklistResponse } from '../models/bookFilter';
import { HttpClient, HttpParams } from '@angular/common/http'
import { BookResponse } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl: string = 'https://localhost:44332/api/Content/'

  constructor(private httpClient: HttpClient) { }

  BookList(filter: BooklistRequest){
    const request = { 
      title: filter.title,
      authorName: filter.authorName,
      publisher: filter.publisher,
      yearMin: filter.yearMin,
      yearMax: filter.yearMax,
      language: filter.language,
      isPresent: filter.isPresent,
      pagesMin: filter.pagesMin,
      pagesMax: filter.pagesMax
    }
    const route = `${this.baseUrl}Books`
    return this.httpClient.post<BooklistResponse>(route, request)
  }

  BookInfo(id: number){
    const route = `${this.baseUrl}Books/${id}`

    let params = new HttpParams().set('id', id);
    return this.httpClient.get<BookResponse>(route, {params: params})
  }
}
