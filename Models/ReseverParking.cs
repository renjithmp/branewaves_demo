using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class ReseverParking
    {
       
        [Key]
        public int Id { get; set; }       
        public String vehicleName { get; set; }
        public String parkingLot { get; set; }
    }
}
