using Candidature.Models.Repositories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidature.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Produit")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Image")]
        public string ImageName { get; set; } = "default-placeholder.png";
        [Required]
        [DisplayName("Prix")]
        public double Price { get; set; }
        [DisplayName("En stock")]
        public bool InStock { get; set; } = false;
        [DisplayName("Quantité")]
        public int Quantity { get; set; } = 0;

        public Product(string name, string description, string image, double price, bool inStock, int quantity)
        {
            Name = name;
            Description = description;
            ImageName = image;
            Price = price;
            InStock = inStock;
            Quantity = quantity;
        }

        public Product()
        {

        }
    }
}
