﻿
using MinimalAPI.Models;
using BookStoreV2.Models.Services;
using BookStoreV2.Services;
using Microsoft.AspNetCore.Identity;

namespace BookStoreV2.Models.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateBook<T>(Book book)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = book,
                Url = StaticDetails.BookApiString + "/book"
            });
        }

        public async Task<T> DeleteBook<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiString + "/book/" + id
            });
        }

        public async Task<T> GetAllBooks<T>()
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiString + "/book"
            });

        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiString + "/book/" + id
            });
        }

        public async Task<T> UpdateBook<T>(Book book)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType = StaticDetails.ApiType.PUT,
                Url = StaticDetails.BookApiString + "/book/" + book.BookId,
                Data = book
            });
        }

        public async Task<T> SearchBook<T>(string searchString)
        {
            return await SendAsync<T>(new Models.ApiRequest
            {
                ApiType= StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiString + $"/book/search?searchString={searchString}"
            });
        }
    }
}
