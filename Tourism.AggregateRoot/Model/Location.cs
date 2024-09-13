using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DTO;

namespace Tourism.AggregateRoot.Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] // Example limit
        public string LocationName { get; set; }

        [MaxLength(250)]
        public string LocationAddress { get; set; }

        [MaxLength(50)]
        public string LocationCity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Cost must be a positive value.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; } // Changed to decimal for currency handling

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0.")]
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
            this.LocationName = locationDto.LocationName;
            this.LocationAddress = locationDto.LocationAddress;
            this.LocationCity = locationDto.LocationCity;
            this.Cost = locationDto.Cost;
            this.Capacity = locationDto.Capacity;

        }

    }
}
