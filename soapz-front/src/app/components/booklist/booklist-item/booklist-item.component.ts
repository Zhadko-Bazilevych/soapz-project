import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BooksView } from 'src/app/models/bookFilter';

@Component({
  selector: 'app-booklist-item',
  templateUrl: './booklist-item.component.html',
  styleUrls: ['./booklist-item.component.css']
})

export class BooklistItemComponent implements OnInit {
  
  @Input() item: BooksView;

  constructor(private router: Router) { }

  ngOnInit(): void {
    
  }

  book(){
    this.router.navigate([`/Book`, this.item.id]);
  }

  
}
