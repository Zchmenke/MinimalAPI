using MinimalAPI.Models;

namespace MinimalAPI.Interfaces
{
    public interface IBookRepository<Book>
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetBookById(int id);
        Task<Book> DeleteBook(int id);
        Task<Book> UpdateBook(Book book);
        Task<Book> AddBook(Book newBook);
        Task<IEnumerable<Book>> SearchForBook(string keyWord);

    }
}
