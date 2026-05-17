using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.BookData;
using LibrarySystem.Shared.LocationData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Repository.LocationRepository
{
    public interface ILocationRepository
    {
        Task<bool> AddLocation(LibraryLocation loation);
        Task<bool> EditLocation(LibraryLocationDetails location);
        Task<LibraryLocation> GetLocationDetails(int id);
        Task<List<LibraryLocation>> GetLocationList();
    }
}
