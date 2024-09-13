using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DTO;
using Tourism.Handler;
using Tourism.DTO;
using Tourism.AggregateRoot;

namespace Tourism.Handler
{
    public interface ILocationHandler
    {
        void CreateLocation(LocationDTO locationDto);

        void DeleteLocation(int id);
        
        LocationDTO GetLocationById(int id);

        IEnumerable<LocationDTO> GetLocations(string searchString);

        void UpdateLocation(LocationDTO locationDto);
    }
}
