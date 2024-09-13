using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.DTO
{
    public class LocationDTO
    {     
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public string LocationCity { get; set; }    
        public decimal Cost { get; set; } 
        public int Capacity { get; set; }
    }
}
