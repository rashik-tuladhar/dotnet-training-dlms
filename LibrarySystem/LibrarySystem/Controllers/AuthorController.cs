using LibrarySystem.Business.AuthorBusiness;
using LibrarySystem.Helpers;
using LibrarySystem.Shared.AuthorData;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorBusiness _authorBusiness;

        public AuthorController(IAuthorBusiness authorBusiness)
        {
            _authorBusiness = authorBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var authorList = await _authorBusiness.GetList();
            return View(authorList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AuthorDetails author)
        {
            if (ModelState.IsValid)
            {
                author.User = "admin";
                bool isAdded = await _authorBusiness.Add(author);
                if (isAdded)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Category added successfully";
                }
                else
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Failed to add category";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }


        public async Task<IActionResult> Edit(string id)
        {
            var authorId = Convert.ToInt32(id);
            var authorDetails = await _authorBusiness.GetDetails(authorId);
            authorDetails.AuthorIdString = EncryptionHelper.Encrypt(authorDetails.AuthorId.ToString());
            return View(authorDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AuthorDetails author)
        {
            author.AuthorId = Convert.ToInt32(EncryptionHelper.Decrypt(author.AuthorIdString));
            if (ModelState.IsValid)
            {
                author.User = "admin";
                var details = await _authorBusiness.Edit(author);
                if (details)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Author details updated successfully";
                }
                else
                {
                    TempData["isSuccess"] = "NO";
                    TempData["Message"] = "Failed to update author details";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }

        public async Task<IActionResult> UpdateStatus(string id)
        {
            var authorId = Convert.ToInt32(id);
            var user = "admin";
            var isUpdated = await _authorBusiness.UpdateStatus(authorId,user);
            if (isUpdated)
            {
                TempData["isSuccess"] = "YES";
                TempData["Message"] = "Author status updated successfully";
            }
            else
            {
                TempData["isSuccess"] = "YES";
                TempData["Message"] = "Failed to update author status";
            }
            return RedirectToAction("Index");
        }


        
    }
}
