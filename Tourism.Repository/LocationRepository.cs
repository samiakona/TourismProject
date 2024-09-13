using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.AggregateRoot.Model;
using Tourism.Repository.Data;

namespace Tourism.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;
        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void DeleteLocation(int id)
        {
            var location = _context.Locations.Find(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }

       

        public void UpdateLocation(Location location)
        {
            var existingLocation = _context.Locations.Local.FirstOrDefault(c => c.Id == location.Id);
            if (existingLocation != null)
            {
                _context.Entry(existingLocation).State = EntityState.Detached;
            }
            _context.Attach(location);
            _context.Entry(location).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public Location GetLocationById(int id)
        {
            return _context.Locations.Find();
        }

        public IEnumerable<Location> GetLocations(string searchString)
        {
           var query = _context.Locations.AsQueryable();
            if (!string.IsNullOrEmpty(searchString)) 
            {
                query = query.Where(c=>c.LocationName.Contains(searchString));
            }
            return query.ToList();
        }
    }
}
