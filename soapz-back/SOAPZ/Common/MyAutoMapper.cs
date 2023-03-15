﻿using AutoMapper;
using System.Runtime;
using static SOAPZ.Operations.Books.BooksResponse;
using static SOAPZ.Operations.MyBooks.MyBooksResponse;

namespace SOAPZ.Common
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            CreateMap<Book, BooksView>()
                .ForMember(dest => dest.Author, act => act.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.Language, act => act.MapFrom(src => src.Language.Name))
                .ForMember(dest => dest.PublishingHouse, act => act.MapFrom(src => src.PublishingHouse.Name))
                .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.Photo));

            CreateMap<Reservation, ReservationsView>()
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.ReservationCode, act => act.MapFrom(src => src.Reservation_code))
                .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.ReceivingDate, act => act.MapFrom(src => src.Receiving_date))
                .ForMember(dest => dest.ExpirationDate, act => act.MapFrom(src => src.Expiration_date))
                .ForMember(dest => dest.ReturningDate, act => act.MapFrom(src => src.Returning_date))
                .ForMember(dest => dest.Isbn, act => act.MapFrom(src => src.Book.Isbn))
                .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.Book.Photo));
        }
    }
}
