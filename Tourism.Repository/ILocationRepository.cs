using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.AggregateRoot.Model;
using Tourism.DTO;

namespace Tourism.Repository
{
    public interface ILocationRepository
    {
        void AddLocation(Location location);
        void DeleteLocation(int id);
        Location GetLocationById(int id);
        IEnumerable<Location> GetLocations(string searchString);
        void UpdateLocation(Location location);
    }
}
