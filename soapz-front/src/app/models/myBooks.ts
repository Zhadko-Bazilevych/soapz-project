import { BaseResponse } from "./baseResponse"

export interface MyBooksResponse extends BaseResponse{
    books: ReservationView[]
}

export interface ReservationView{
    title: string,
    reservationCode: number,
    status: string,
    reservationDate: Date,
    receivingDate: Date,
    expirationDate: Date,
    returningDate: Date,
    isbn: string,
    photo: string
}

export interface ReservationViewResponse extends BaseResponse
{
    reservation: ReservationView
}