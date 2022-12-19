import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { BooklistRequest, BooksView } from 'src/app/models/bookFilter';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-booklist',
  templateUrl: './booklist.component.html',
  styleUrls: ['./booklist.component.css']
})

export class BooklistComponent implements OnInit {
  bookList: BooksView[] = []

  constructor(private bookService: BookService) { }

  ngOnInit(): void {

  }

  async UpdateBookList(booklistRequest: BooklistRequest){
    const response = await firstValueFrom(this.bookService.BookList(booklistRequest));
    if(response == null)
    {
      this.bookList = []
    }
    else
    {
      this.bookList = response!.books
    }
  }


}
