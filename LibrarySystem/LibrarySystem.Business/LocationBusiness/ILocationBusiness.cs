using LibrarySystem.Shared.BookData;
using LibrarySystem.Shared.LocationData;

namespace LibrarySystem.Business.LocationBusiness
{
    public interface ILocationBusiness
    {
        Task<bool> AddLocation(LibraryLocationDetails location);
        Task<bool> EditLocation(LibraryLocationDetails location);
        Task<LibraryLocationDetails> GetLocationDetails(int id);
        Task<List<LibraryLocationDetails>> GetLocationList();
    }
}
