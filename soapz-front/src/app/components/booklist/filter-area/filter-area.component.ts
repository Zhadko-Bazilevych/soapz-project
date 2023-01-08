import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { BookService } from 'src/app/services/book.service';
import { BooklistRequest, BooksView } from '../../../models/bookFilter';

@Component({
  selector: 'app-filter-area',
  templateUrl: './filter-area.component.html',
  styleUrls: ['./filter-area.component.css']
})
export class FilterAreaComponent implements OnInit {

  @Output() onFilterComplete = new EventEmitter<BooklistRequest>();
  
  forma = new FormGroup({
    title: new FormControl(),
    authorName: new FormControl(),
    publisher: new FormControl(),
    yearMin: new FormControl(),
    yearMax: new FormControl(),
    language: new FormControl(),
    isPresent: new FormControl(),
    pagesMin: new FormControl(),
    pagesMax: new FormControl()
  })
  get title() { return this.forma.get('title') }
  get authorName() { return this.forma.get('authorName') }
  get publisher() { return this.forma.get('publisher') }
  get yearMin() { return this.forma.get('yearMin') }
  get yearMax() { return this.forma.get('yearMax') }
  get language() { return this.forma.get('language') }
  get isPresent() { return this.forma.get('isPresent') }
  get pagesMin() { return this.forma.get('pagesMin') }
  get pagesMax() { return this.forma.get('pagesMax') }

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.Filtered()
  }

  async Filtered() {
    if (this.forma.valid) {
      const bookRequest = {
        title: this.title?.value,
        authorName: this.authorName?.value,
        publisher: this.publisher?.value,
        yearMin: this.yearMin?.value,
        yearMax: this.yearMax?.value,
        language: this.language?.value,
        isPresent: this.isPresent?.value,
        pagesMin: this.pagesMin?.value,
        pagesMax: this.pagesMax?.value
      }
      this.onFilterComplete.emit(bookRequest)
      
    }
  }
}
