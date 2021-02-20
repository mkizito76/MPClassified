using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Product Name cannot be less than 10 characters")]
        public string ProductName { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Brand cannot be less than 3 characters")]
        public string Brand { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Type cannot be less than 3 characters")]
        public string Type { get; set; }
    }
}