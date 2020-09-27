using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelFinder.Entity
{
    public class Hotel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string City { get; set; }
    }
}
