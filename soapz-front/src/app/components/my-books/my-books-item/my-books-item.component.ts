import { Component, Input, OnInit } from '@angular/core';
import { ReservationView } from 'src/app/models/myBooks';

@Component({
  selector: 'app-my-books-item',
  templateUrl: './my-books-item.component.html',
  styleUrls: ['./my-books-item.component.css']
})
export class MyBooksItemComponent implements OnInit {
  
  @Input() item: ReservationView;

  constructor() { }

  ngOnInit(): void {
    
  }
  
}
