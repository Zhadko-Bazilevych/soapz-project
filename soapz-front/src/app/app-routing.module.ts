import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from './components/book/book.component';
import { BooklistComponent } from './components/booklist/booklist.component';
import { FilterAreaComponent } from './components/booklist/filter-area/filter-area.component';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { MyBooksComponent } from './components/my-books/my-books.component';
import { RegisterComponent } from './components/register/register.component';
import { UpdateStatusComponent } from './components/update-status/update-status.component';

const routes: Routes = [
  {path:'Home', component:BooklistComponent},
  {path:'Book/:id', component:BookComponent},
  {path:'Login', component:LoginComponent},
  {path:'Register', component:RegisterComponent},
  {path:'MyBooks', component:MyBooksComponent},
  {path:'Reservations', component:UpdateStatusComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
