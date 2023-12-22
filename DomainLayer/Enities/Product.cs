using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Enities
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; } 

        public int Price { get; set; } = 0;

        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;

        public string? Description { get; set; }

    }
}
