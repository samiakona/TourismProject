using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.AggregateRoot.Model;
using Tourism.DTO;
using Tourism.Repository;

namespace Tourism.Handler
{
    public class LocationHandler : ILocationHandler
    {
        private readonly ILocationRepository _locationRepository;
        public LocationHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public void CreateLocation(LocationDTO locationDto)
        {
            var location = new Location();
            location.MapToDTO(locationDto);
            _locationRepository.AddLocation(location);

        }

        public void DeleteLocation(int id)
        {
            _locationRepository.DeleteLocation(id);
        }

       
        public void UpdateLocation(LocationDTO locationDto)
        {
           var location = _locationRepository.GetLocationById(locationDto.Id);
            if(location == null)
            {
                throw new ArgumentException("Location Not Found");
            }
            location.MapToDTO(locationDto);
            _locationRepository.UpdateLocation(location);

        }

        public LocationDTO GetLocationById(int id)
        {
            var location = _locationRepository.GetLocationById(id);
            if (location == null)
            {
                return null;
            }
            var locationDto= new LocationDTO();
            location.MapToDTO(locationDto);
            return locationDto;
        }

        public IEnumerable<LocationDTO> GetLocations(string searchString)
        {
            var locations = _locationRepository.GetLocations(searchString);
            return locations.Select(Location =>
            {
                var locationDto = new LocationDTO();
                Location.MapToDTO(locationDto);
                return locationDto;
               
            });
        }
    }
}
