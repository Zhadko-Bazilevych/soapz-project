import { Component, OnInit } from '@angular/core';
import { firstValueFrom, Subscription } from 'rxjs';
import { ReservationView } from 'src/app/models/myBooks';
import { MyBookService } from 'src/app/services/my-book.service';

@Component({
  selector: 'app-my-books',
  templateUrl: './my-books.component.html',
  styleUrls: ['./my-books.component.css']
})
export class MyBooksComponent  implements OnInit {
  bookList: ReservationView[] = [] 

  isTouched: boolean = false

  constructor(private bookService: MyBookService) { }

  ngOnInit(): void {
    this.UpdateMyBooks()
  }

  async UpdateMyBooks(){
    const response = await firstValueFrom(this.bookService.MyBooks());
    this.isTouched = true
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