using BookStoreV2.Models.Services;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Interfaces;
using MinimalAPI.Models;

namespace BookStoreV2.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        /////////////////////////////////////////////////////
        [HttpGet]
        public async Task<IActionResult> ViewBooks()
        {
            var response = await _bookService.GetAllBooks<List<Book>>();
            if (response != null)
            {
                return View(response);

            }
            return View(response);
        }
        /////////////////////////////////////////////////////
        [HttpGet]
        public async Task<IActionResult> ViewOneBook(int id)
        {
            var response = await _bookService.GetBookById<Book>(id);
            if (response != null)
            {
                return View(response);
            }
            return View(response);
        }

        /////////////////////////////////////////////////////
        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            return View("AddBook");
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var response = await _bookService.CreateBook<Book>(book);
            if (response != null)
            {
                return RedirectToAction(nameof(ViewBooks));
            }
            return View("AddBook");
        }
        //////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook<Book>(id);
            if (response != null)
            {
                return RedirectToAction(nameof(ViewBooks));
            }
            return RedirectToAction(nameof(ViewBooks));
        }
        //////////////////////////////////////////////////////////
        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var response = await _bookService.GetBookById<Book>(id);
            return View("UpdateBook", response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book book)
        {

            var response = await _bookService.UpdateBook<Book>(book);
            if (response != null)
            {
                return RedirectToAction(nameof(ViewBooks));
            }
            return RedirectToAction(nameof(ViewBooks));
        }
        //////////////////////////////////////////////////////////
        [HttpGet]
        public async Task<IActionResult> SearchBook(string searchString)
        {
            var response = await _bookService.SearchBook<List<Book>>(searchString);
            if (response!=null)
            {
                return View("SearchBook",response);
            }
            return View("SearchBook");
        }
    }

}
