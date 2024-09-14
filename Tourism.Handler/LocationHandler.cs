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
            // Create a new instance of Location
            var location = new Location();

            // Map properties from DTO to Location instance
            location.MapFromDTO(locationDto);

            // Validate the location using your custom validation logic
            List<string> validationErrors;
            if (!location.validate(out validationErrors))
            {
                // Handle validation errors, for example, by logging or throwing an exception
                foreach (var error in validationErrors)
                {
                    Console.WriteLine(error); // Or handle errors as required
                }
                return; // Exit the method since validation failed
            }

            // If valid, add the location to the repository
            _locationRepository.AddLocation(location);
        }


        public void UpdateLocation(LocationDTO locationDto)
        {

            List<string> validationErrors;

            // Retrieve the location from the repository
            var location = _locationRepository.GetLocationById(locationDto.Id);

            // Map the DTO values to the Location entity
            location.MapFromDTO(locationDto);

            // Validate the updated location
            if (!location.validate(out validationErrors))
            {
                foreach (var error in validationErrors)
                {
                    Console.WriteLine(error); // Or handle errors as required
                }
                return;
            }

            // If validation passes, update the location in the repository
            _locationRepository.UpdateLocation(location);
           
        }



        public void DeleteLocation(int id)
        {
            _locationRepository.DeleteLocation(id);
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
