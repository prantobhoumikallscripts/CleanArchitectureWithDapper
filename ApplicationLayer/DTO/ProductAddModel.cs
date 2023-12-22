using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class ProductAddModel
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; } = 0;

        public string? Description { get; set; }
    }
}
