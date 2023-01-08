import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { BookInfo } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';
import { faBook } from '@fortawesome/free-solid-svg-icons';
import { AuthenticationService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user.model';
import { MyBookService } from 'src/app/services/my-book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  book: BookInfo
  faBook = faBook
  user: User | null
  error: string | null

  constructor(private bookService: BookService, private activatedRoute: ActivatedRoute, private authenticationService: AuthenticationService, private router: Router, private myBookService: MyBookService) { }

  ngOnInit(): void {
    let param = this.activatedRoute.snapshot.paramMap.get('id')
    let id = param == null ? -1 : +param
    this.BookInfo(id)
  }

  async BookInfo(id: number) {
    const response = await firstValueFrom(this.bookService.BookInfo(id));
    this.book = response.book
  }

  async Reservation() {
    this.error = null
    this.user = this.authenticationService.Local()
    if (this.user != null) {
      const result = await firstValueFrom(this.myBookService.Reservate(this.book.id));
      if(result.code != 200)
      {
        this.error = result.message
      }
      else{
        this.router.navigate([`/MyBooks`]);
      }
    }
    else {
      this.router.navigate([`/Login`]);
    }
  }
}
