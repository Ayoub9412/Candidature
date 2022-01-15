using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidature.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Produit")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        [DisplayName("Prix")]
        public double Price { get; set; }

        [DisplayName("En stock")]
        public bool InStock { get; set; } = false;

        [DisplayName("Quantité")]
        public int Quantity { get; set; } = 0;

        public ProductViewModel()
        {

        }
    }
}
