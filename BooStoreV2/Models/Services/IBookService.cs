using MinimalAPI.Models;
using System.Net.Http.Headers;

namespace BookStoreV2.Models.Services
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetBookById<T>(int id);
        Task<T> CreateBook<T>(Book book);
        Task<T> UpdateBook<T>(Book book);
        Task<T> DeleteBook<T>(int id);
        Task<T> SearchBook<T>(string searchWord);
        

    }
}
