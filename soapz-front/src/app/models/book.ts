import { BaseResponse } from "./baseResponse"

export interface BookResponse extends BaseResponse{
    book: BookInfo
}

export interface BookInfo{
    id: number,
    title: string,
    description: string
    yearPublished: number,
    isbn: string,
    pages: number,
    amount: number,
    publishingHouse: string,
    language: string,
    author: string,
    authorPhoto: string,
    authorDescription: string,
    photo: string,
    genres: string[]
}