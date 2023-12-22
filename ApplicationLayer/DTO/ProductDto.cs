using DomainLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    //public class ProductDto
    //{
    //    [Required (ErrorMessage = "ProductName  Feild is reqired")]
    //    public string ProductName { get; set; }



    //    [Required  (ErrorMessage = "Price Feild is reqired")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Price Only positive number allowed")]
    //    public int Price { get; set; }
    //    public string? Description { get; set; }
    //}

    public class ProductDto
    {
     
        public int Id { get; set; }


      
        public string ProductName { get; set; }

 
        public int Price { get; set; }


        public string? Description { get; set; }

        public DateTime  ReleaseDate { get; set; }

      
    }
}
