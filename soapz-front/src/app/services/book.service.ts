import { Injectable } from '@angular/core';
import { BooklistRequest, BooklistResponse } from '../models/bookFilter';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl: string = 'https://localhost:44332'

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
    const route = `${this.baseUrl}/api/Content/Books`
    return this.httpClient.post<BooklistResponse>(route, request)
  }
}
