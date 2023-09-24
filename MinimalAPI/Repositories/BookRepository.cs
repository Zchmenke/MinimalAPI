using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Context;
using MinimalAPI.Interfaces;
using MinimalAPI.Models;

namespace MinimalAPI.Repositories
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(Book newBook)
        {
            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var bookToDelete = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                await _context.SaveChangesAsync();
            }
            return bookToDelete;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<Book> UpdateBook(Book book)
        {

            var bookToUpdate = await _context.Books
                .FirstOrDefaultAsync(b => b.BookId == book.BookId);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.ReleaseYear = book.ReleaseYear;
                bookToUpdate.Available = book.Available;

                await _context.SaveChangesAsync();
                return bookToUpdate;
            }
            return null;
        }
        public async Task<IEnumerable<Book>> SearchForBook(string keyWord)
        {
            List<Book> tempList = await _context.Books
                .Where(b => b.Author.ToLower()
                .Contains(keyWord) ||
                b.Title.ToLower()
                .Contains(keyWord) ||
                b.Genre.ToLower() == keyWord)
                .ToListAsync();

            if (tempList.Count == 0)
            {
                return null;
            }
            return tempList;
        }
    }
}
