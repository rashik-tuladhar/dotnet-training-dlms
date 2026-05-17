using LibrarySystem.Repository.LocationRepository;
using LibrarySystem.Shared.LocationData;
namespace LibrarySystem.Business.LocationBusiness
{
    public class LocationBusiness : ILocationBusiness
    {
        private readonly ILocationRepository _locationRepository;

        public LocationBusiness(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<bool> AddLocation(LibraryLocationDetails location)
        {
            var locationEntity = new Repository.Models.LibraryLocation
            {
                Aisle = location.Aisle,
                Shelf = location.Shelf,
                Section = location.Section,
                Floor = location.Floor,
                Description = location.Description
            };
            return await _locationRepository.AddLocation(locationEntity);
        }

        public async Task<bool> EditLocation(LibraryLocationDetails location)
        {
            return await _locationRepository.EditLocation(location);
        }

        public async Task<LibraryLocationDetails> GetLocationDetails(int id)
        {
            var locationData = await _locationRepository.GetLocationDetails(id);
            var locationDetails = new LibraryLocationDetails
            {
                LocationId = locationData.LocationId,
                Aisle = locationData.Aisle,
                Shelf = locationData.Shelf,
                Section = locationData.Section,
                Floor = locationData.Floor,
                Description = locationData.Description
            };
            return locationDetails;
        }

        public async Task<List<LibraryLocationDetails>> GetLocationList()
        {
            List<LibraryLocationDetails> locationList = new List<LibraryLocationDetails>();
            var locations = await _locationRepository.GetLocationList();
            foreach (var location in locations)
            {
                locationList.Add(new LibraryLocationDetails
                {
                    LocationId = location.LocationId,
                    Aisle = location.Aisle,
                    Shelf = location.Shelf,
                    Section = location.Section,
                    Floor = location.Floor,
                    Description = location.Description
                });
            }
            return locationList;
        }
    }
}
