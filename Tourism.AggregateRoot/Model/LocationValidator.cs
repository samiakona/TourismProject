using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.AggregateRoot.Model
{
    public class LocationValidator
    {

        public bool Validate(Location location, out List<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(location.LocationName) && (location.LocationName.Length > 100))
            {
                validationErrors.Add("Location Name is Required and can't exceed 100 word.");
            }


            if (!string.IsNullOrWhiteSpace(location.LocationAddress) && location.LocationAddress.Length>250)
            {
                validationErrors.Add("Location Name is Required");
            }


            if (!string.IsNullOrWhiteSpace(location.LocationCity) && (location.LocationCity.Length>50))
            {
                validationErrors.Add("LocationCity cannot exceed 50 characters.");
            }

            if (location.Cost>0)
            {
                validationErrors.Add("Cost must be a positive value.");
            }

            if (location.Capacity > 0)
            {
                validationErrors.Add("Capacity must be greater than 0.");
            }

            return validationErrors.Count == 0;
        }
    }
}
