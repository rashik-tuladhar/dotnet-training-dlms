using LibrarySystem.Business.AuthorBusiness;
using LibrarySystem.Business.BookBusiness;
using LibrarySystem.Shared.BookData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibrarySystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookBusiness _bookBusiness;
        private readonly IAuthorBusiness _authorBusiness;

        public BookController(IBookBusiness bookBusiness, IAuthorBusiness authorBusiness)
        {
            _bookBusiness = bookBusiness;
            _authorBusiness = authorBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var bookList = await _bookBusiness.GetBookList();
            return View(bookList);
        }

        public async Task<IActionResult> AddBook()
        {
            BookDetails bookDetails = new BookDetails();
            var authorList = await _authorBusiness.GetList();
            bookDetails.AuthorList = authorList.Select(a => new SelectListItem
            {
                Value = a.AuthorId.ToString(),
                Text = a.FirstName + " " + a.LastName
            }).ToList();
            return View(bookDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(BookDetails book)
        {
            if (ModelState.IsValid)
            {
                book.User = "admin";
                bool isAdded = await _bookBusiness.AddBook(book);
                if (isAdded)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Book added successfully";
                }
                else
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Failed to add book";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }


        public async Task<IActionResult> EditBook(string id)
        {
            var bookId = Convert.ToInt32(id);
            var bookDetails = await _bookBusiness.GetBookDetails(bookId);
            var authorList = await _authorBusiness.GetList();
            bookDetails.AuthorList = authorList.Select(a => new SelectListItem
            {
                Value = a.AuthorId.ToString(),
                Text = a.FirstName + " " + a.LastName,
                Selected = a.AuthorId.ToString() == bookDetails.Author
            }).ToList();
            return View(bookDetails);
        }

        public async Task<IActionResult> UpdateStatus(string id)
        {
            var bookId = Convert.ToInt32(id);
            var user = "admin";
            var isUpdated = await _bookBusiness.UpdateStatus(bookId,user);
            if (isUpdated)
            {
                TempData["isSuccess"] = "YES";
                TempData["Message"] = "Book status updated successfully";
            }
            else
            {
                TempData["isSuccess"] = "YES";
                TempData["Message"] = "Failed to update book status";
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(BookDetails book)
        {
            if (ModelState.IsValid)
            {
                book.User = "admin";
                var details = await _bookBusiness.EditBooks(book);
                if (details)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Book details updated successfully";
                }
                else
                {
                    TempData["isSuccess"] = "NO";
                    TempData["Message"] = "Failed to update book details";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
    }
}
