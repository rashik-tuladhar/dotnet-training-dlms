using LibrarySystem.Business.MemberBusiness;
using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.MemberData;
using LibrarySystem.Shared.PublicationData;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberBusiness _memberBusiness;
        public MemberController(IMemberBusiness memberBusiness)
        {
            _memberBusiness = memberBusiness;
        }
        public async Task<IActionResult> Index()
        {
            var memberList = await _memberBusiness.ViewAllList();
            return View(memberList);
        }

        public IActionResult AddMembers()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddMembers(MemberDetails member)
        
        {

            if (ModelState.IsValid)
            {
                //if (book.Name != "hello")
                //{
                //    ModelState.AddModelError("Name", "Hello custom error");
                //}
                bool isAdded = await _memberBusiness.AddMembers(member);
                if (isAdded)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Member added successfully";
                }
                else
                {
                    TempData["isSuccess"] = "No";
                    TempData["Message"] = "Failed to add Member";
                }
                return RedirectToAction("AddMembers");
            }
            else
            {
                return View(member);
            }
        }

        public async Task<IActionResult> EditMembers(string id)
        {
            var memberId = Convert.ToInt32(id);
            var memberDetails = await _memberBusiness.GetMemberDetails(memberId);
            return View(memberDetails);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMembers(MemberDetails member)
        {
            if (ModelState.IsValid)
            {
                var details = await _memberBusiness.EditMembers(member);
                if (details)
                {
                    TempData["Message"] = "Member details updated successfully";
                }
                else
                {
                    TempData["isSuccess"] = "NO";
                    TempData["Message"] = "Failed to update Member details";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(member);
            }
        }

        public async Task<IActionResult> RenewMembership(int id)
        {
            //int memberId = Convert.ToInt32(id);

            var member = await _memberBusiness.GetMemberDetails(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }


        [HttpPost]
        public async Task<IActionResult> RenewMembership(int memberId, int days)
        {
            await _memberBusiness.RenewMembership(memberId,  days);

            return RedirectToAction("Index");
        }
    }
}
