using LibrarySystem.Business.PublicationBusiness;
using LibrarySystem.Shared.PublicationData;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class PublicationController : Controller
    {
        private readonly IPublicationBusiness _publicationBusiness;

        public PublicationController(IPublicationBusiness publicationBusiness)
        {
            _publicationBusiness = publicationBusiness;
        }

        public async Task<IActionResult> Index()
        {
            //var categoryList = await _publicationBusiness.GetCategoryList();
            List<PublicationDetails> categoryList = new List<PublicationDetails>();
            return View(categoryList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PublicationDetails category)
        {
            if (ModelState.IsValid)
            {
                category.User = "admin";
                bool isAdded = await _publicationBusiness.Add(category);
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
                return View(category);
            }
        }


        public async Task<IActionResult> Edit(string id)
        {
            var categoryId = Convert.ToInt32(id);
            var categoryDetails = await _publicationBusiness.GetDetails(categoryId);
            return View(categoryDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PublicationDetails category)
        {
            if (ModelState.IsValid)
            {
                category.User = "admin";
                var details = await _publicationBusiness.Edit(category);
                if (details)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Category details updated successfully";
                }
                else
                {
                    TempData["isSuccess"] = "NO";
                    TempData["Message"] = "Failed to update category details";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public async Task<IActionResult> UpdateStatus(string id)
        {
            var categoryId = Convert.ToInt32(id);
            var user = "admin";
            var isUpdated = await _publicationBusiness.UpdateStatus(categoryId,user);
            if (isUpdated)
            {
                TempData["isSuccess"] = "YES";
                TempData["Message"] = "Category status updated successfully";
            }
            else
            {
                TempData["isSuccess"] = "YES";
                TempData["Message"] = "Failed to update category status";
            }
            return RedirectToAction("Index");
        }


        
    }
}
