using LibrarySystem.Business.MemberBusiness;
using LibrarySystem.Shared.MemberData;
using LibrarySystem.Shared.PublicationData;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberBusiness _memberBusiness;   
        
        public MemberController (IMemberBusiness memberBusiness)
        {
            _memberBusiness = memberBusiness;
        }
        public async Task<IActionResult> Index(string searchText)
        {
            var MemberList = await _memberBusiness.GetMemberList(searchText);
            return View(MemberList);
        }
        public async Task<IActionResult> AddMember(MemberDetails Members)
        {

            if (ModelState.IsValid)
            {
                //if (book.Name != "hello")
                //{
                //    ModelState.AddModelError("Name", "Hello custom error");
                //}
                bool isAdded = await _memberBusiness.AddMember(Members);
                if (isAdded)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Member added successfully";
                }
                else
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Failed to add member";
                }
                return RedirectToAction("AddMember");
            }
            else
            {
                return View(Members);
            }
        }


    }
}
