import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { FilterAreaComponent } from './components/booklist/filter-area/filter-area.component';
import { BooklistComponent } from './components/booklist/booklist.component';
import { BooklistItemComponent } from './components/booklist/booklist-item/booklist-item.component';
import { BookComponent } from './components/book/book.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { MyBooksComponent } from './components/my-books/my-books.component';
import { MyBooksItemComponent } from './components/my-books/my-books-item/my-books-item.component';
import { UpdateStatusComponent } from './components/update-status/update-status.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    FilterAreaComponent,
    BooklistComponent,
    BooklistItemComponent,
    BookComponent,
    LoginComponent,
    RegisterComponent,
    MyBooksComponent,
    MyBooksItemComponent,
    UpdateStatusComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
