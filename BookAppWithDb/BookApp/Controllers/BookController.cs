using BookApp.Models;
using BookApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookApp.Controllers
{
    public class BookController : Controller
    {
        readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> GetAllBooks()
        {
            return View(await _bookService.GetAllBooks());
        }

        public async Task<IActionResult> AddBook()
        {
            ViewData["AuthorId"] = new SelectList(await _bookService.GetAllAuthors(), "AuthorId", "AuthorName");
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            ModelState.Remove("Author");
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            else
            {
                int effectedRows = await _bookService.AddBook(book);
                if (effectedRows > 0)
                {
                    TempData["message"] = "Book Added Succesfuly";
                    return RedirectToAction("GetAllBooks");
                }
                else
                {
                    TempData["message"] = "Book Addition Failed";
                    return View(book);
                }
            }
        }

        public async Task<IActionResult> GetBookById(int id)
        {
            Book GetBoob = await _bookService.GetBookById(id);
            if(GetBoob != null)
            {
                return View(await _bookService.GetBookById(id));
            }
            TempData["message"] = "Book Not Found";
            return View();
            
        }
        //[HttpGet]
        //public async Task<IActionResult> DeleteBookById(int id)
        //{ 
        //    Book book = await _bookService.GetBookById(id);
        //    if (book != null)
        //    {
        //        return View(book);
        //    }
        //    return RedirectToAction("GetAllBooks");
        //}
        //[HttpPost]
        //public async Task<IActionResult> DeleteConfirm(int id)
        //{
        //    int deleteitem = await _bookService.DeleteBookById(id);
        //    if (deleteitem>0)
        //    {

        //        return RedirectToAction("GetAllBooks");
        //    }
        //    TempData["message"] = "Book Not Found";
        //    return RedirectToAction("GetAllBooks");

        //}

        [HttpGet]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            Book book = await _bookService.GetBookById(id);

            if (book == null)
            {
                TempData["msg"] = "Book not found";
                return View(book);
                //return RedirectToAction("GetAllBooks");
            }
            return View(book);
        }

        
        [HttpPost]
        public async Task<IActionResult> DeleteBookById(Book book)
        {
            
            int deleteResult = await _bookService.DeleteBookById(book.BookId);
            
            if (deleteResult > 0)
            {
                return RedirectToAction("GetAllBooks");
            }
            else
            {
                
                TempData["msg"] = "Book not found";
                return View(book);
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            Book bookExist = await _bookService.GetBookById(id);
            if (bookExist == null)
            {
                TempData["Updatemsg"] = "Book not found";
                return View();
            }
            ViewData["AuthorId"] = new SelectList(await _bookService.GetAllAuthors(), "AuthorId", "AuthorName");
            return View(bookExist);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            //Book bookExist = await _bookService.GetBookById(book.BookId);
            int updateditem = await _bookService.UpdateBook(book);
            if (updateditem > 0)
            {
                TempData["Updatemsg"] = "Data Updated";
                return RedirectToAction("GetAllBooks");
            }
            else
            {

                TempData["Updatemsg"] = "Book not found";
                return View(book);
            }

        }


    }
}
