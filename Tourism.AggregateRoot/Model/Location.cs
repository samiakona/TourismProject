using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DTO;
using System.Globalization;

namespace Tourism.AggregateRoot.Model
{
    public class Location
    {
       
       [Key]
        public int Id { get; set; }

        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public string LocationCity { get; set; }
 
        public decimal Cost { get; set; } // Changed to decimal for currency handling

        public int Capacity { get; set; }


        // Mapping to DTO
        // Mapping to an existing DTO
        public void MapToDTO(LocationDTO locationDto)
        {
            locationDto.Id = this.Id;
            locationDto.LocationName = this.LocationName;
            locationDto.LocationAddress = this.LocationAddress;
            locationDto.LocationCity = this.LocationCity;
            locationDto.Cost = (int)this.Cost;
            locationDto.Capacity = this.Capacity;

        }


        // Mapping from DTO

        public void MapFromDTO(LocationDTO locationDto)
        {
            this.Id = locationDto.Id;
            this.LocationName = locationDto.LocationName;  // LocationName is set here from DTO
            this.LocationAddress = locationDto.LocationAddress;
            this.LocationCity = locationDto.LocationCity;
            this.Cost = locationDto.Cost;
            this.Capacity = locationDto.Capacity;
        }



        public bool validate(out List<string> validationErrors)
        {
            var validator = new LocationValidator();
            return validator.Validate(this, out validationErrors);
        }




    }
}



