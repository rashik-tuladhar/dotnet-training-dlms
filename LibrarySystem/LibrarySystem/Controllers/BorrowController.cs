using LibrarySystem.Business.AuthorBusiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibrarySystem.Controllers
{
    public class BorrowController : Controller
    {
        private readonly IAuthorBusiness _authorBusiness;

        public BorrowController(IAuthorBusiness authorBusiness)
        {
            _authorBusiness = authorBusiness;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            var authorList = await _authorBusiness.GetList();
            var selectListItem = authorList.Select(a => new SelectListItem
            {
                Text = a.FirstName,
                Value = a.AuthorId.ToString()
            }).ToList();
            return View();
        }
    }
}
