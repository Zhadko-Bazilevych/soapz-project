import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { ReservationView } from 'src/app/models/myBooks';
import { BookByCodeService } from 'src/app/services/book-by-code.service';

@Component({
  selector: 'app-update-status',
  templateUrl: './update-status.component.html',
  styleUrls: ['./update-status.component.css']
})
export class UpdateStatusComponent implements OnInit {
  View: ReservationView | null
  insertError: string | null
  updateError: string | null
  statuses = ["Given","Taken","Unvisited","Taken late","Not taken","Compensated"];
  submited: boolean = false;

  newStatus = new FormGroup({
    status: new FormControl(null,Validators.required),
  });
  get getstatus() { return this.newStatus.get('status') }  

  //0-Reservated, 1-Given, 2-Taken or others
  resStatus: number

  CodeInsert = new FormGroup({
    code: new FormControl<number>(0,[Validators.required]),
  })
  get code() { return this.CodeInsert.get('code') }

  constructor(private bookService: BookByCodeService) { }

  ngOnInit(): void {
    
  }

  async Inserted() {
    this.insertError = null
    if (this.CodeInsert.valid) {
      const response = await firstValueFrom(this.bookService.BookByCode(this.code!.value??0))

      if(response.code != 200)
      {
        this.View = null
        this.insertError = response.message
      }
      if(!this.insertError)
      {
        this.View = response.reservation
        this.resStatus = this.View.status=='Reservated'?0:(this.View.status=='Given'?1:2)
      }
    }
  }

  async Change() {
    this.submited = true;
    if (this.newStatus.valid) {
      this.updateError = null
      const response = await firstValueFrom(this.bookService.UpdateStatus(this.View!.reservationCode, this.getstatus!.value??''))

      if(response.code != 200)
      {
        this.updateError = response.message
      }
      if(!this.updateError)
      {
        this.Inserted() 
      }
    }
  }
}
