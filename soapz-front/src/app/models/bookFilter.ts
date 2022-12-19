import { BaseResponse } from "./baseResponse"

export interface BooklistRequest{
    title: string | null | undefined,
    authorName: string | null | undefined,
    publisher: string | null | undefined,
    yearMin: number | null | undefined,
    yearMax: number | null | undefined,
    language: string | null | undefined,
    isPresent: boolean | null | undefined,
    pagesMin: number | null | undefined,
    pagesMax: number | null | undefined,
}

export interface BooklistResponse extends BaseResponse{
    books: BooksView[],
    count: number
}

export interface BooksView{
    id: number,
    title: string,
    yearPublished: number,
    pages: number,
    amount: number,
    publishingHouse: string,
    language: string,
    author: string,
    photo: string
}