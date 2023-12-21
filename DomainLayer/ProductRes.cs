using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ProductRes
    {
     
        public string ProductName { get; set; } 

        [Required]
        public int Price { get; set; } 


        [Required]
        public DateTime ReleaseDate { get; set; }

        public string? Description { get; set; }


        public List<Product> Products { get; set; } = null;
    }


}
