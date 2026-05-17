using LibrarySystem.Business.LocationBusiness;
using LibrarySystem.Shared.LocationData;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationBusiness _locationBusiness;

        public LocationController(ILocationBusiness locationBusiness)
        {
            _locationBusiness = locationBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var locationList = await _locationBusiness.GetLocationList();
            return View(locationList);
        }


        public IActionResult AddLocation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLocation(LibraryLocationDetails libraryLocation)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _locationBusiness.AddLocation(libraryLocation);
                if (isAdded)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Location Added Successfully";
                }
                else
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Failed to Add Location";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(libraryLocation);
            }
        }

        public async Task<IActionResult> EditLocation(string id)
        {
            var locationId = Convert.ToInt32(id);
            var locationDetails = await _locationBusiness.GetLocationDetails(locationId);
            return View(locationDetails);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLocation(LibraryLocationDetails libraryLocation)
        {
            if (ModelState.IsValid)
            {
                var details = await _locationBusiness.EditLocation(libraryLocation);
                if (details)
                {
                    TempData["isSuccess"] = "YES";
                    TempData["Message"] = "Location Updated Successfully";
                }
                else
                {
                    TempData["isSuccess"] = "NO";
                    TempData["Message"] = "Failed to Update Location";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(libraryLocation);
            }
        }

    }
}
