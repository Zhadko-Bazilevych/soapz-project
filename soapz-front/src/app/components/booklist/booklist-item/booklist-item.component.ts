import { Component, Input, OnInit } from '@angular/core';
import { BooksView } from 'src/app/models/bookFilter';

@Component({
  selector: 'app-booklist-item',
  templateUrl: './booklist-item.component.html',
  styleUrls: ['./booklist-item.component.css']
})
export class BooklistItemComponent implements OnInit {
  
  @Input() item: BooksView;

  ngOnInit(): void {
    
  }

}
