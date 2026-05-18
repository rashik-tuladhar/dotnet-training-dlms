using LibrarySystem.Business.LocationBusiness;
using LibrarySystem.Business.MemberBusiness;
using LibrarySystem.Shared.LocationData;
using LibrarySystem.Shared.MemberData;
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
            var memberList = await _memberBusiness.GetMemberList();
            return View(memberList);
        }

        public IActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMember(MemberDetails member)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _memberBusiness.AddMember(member);
                if (isAdded)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Member Added Successfully";
                }
                else
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Failed to Add Member";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(member);
            }
        }


        public async Task<IActionResult> EditMember(string id)
        {
            var memberId = Convert.ToInt32(id);
            var memberDetails = await _memberBusiness.GetMemberDetails(memberId);
            return View(memberDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMember(MemberDetails member)
        {
            if (ModelState.IsValid)
            {
                var details = await _memberBusiness.EditMember(member);
                if (details)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Member Updated Successfully";
                }
                else
                {
                    TempData["isSuccess"] = "NO";
                    TempData["Message"] = "Failed to Update Member Details";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(member);
            }
        }

    }
}
