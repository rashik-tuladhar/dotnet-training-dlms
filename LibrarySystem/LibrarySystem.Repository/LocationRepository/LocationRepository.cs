using LibrarySystem.Repository.Data;
using LibrarySystem.Repository.Models;
using LibrarySystem.Shared.LocationData;
using Microsoft.EntityFrameworkCore;
namespace LibrarySystem.Repository.LocationRepository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLocation(LibraryLocation location)
        {
            await _context.LibraryLocations.AddAsync(location);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }

        public async Task<bool> EditLocation(LibraryLocationDetails location)
        {
            var locationDetails = _context.LibraryLocations.FirstOrDefault(x => x.LocationId == location.LocationId);
            if (locationDetails != null)
            {
                locationDetails.Aisle = location.Aisle;
                locationDetails.Shelf = location.Shelf;
                locationDetails.Section = location.Section;
                locationDetails.Floor = location.Floor;
                locationDetails.Description = location.Description;
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
            }
            return false;
        }

        public async Task<LibraryLocation> GetLocationDetails(int id)
        {
            var locationDetails = await _context.LibraryLocations.AsNoTracking().FirstOrDefaultAsync(x => x.LocationId == id);
            return locationDetails;

        }

        public async Task<List<LibraryLocation>> GetLocationList()
        {
            var locationList = await _context.LibraryLocations.AsNoTracking().OrderByDescending(x => x.LocationId).ToListAsync();
            return locationList;

        }
    }
}
