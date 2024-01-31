using System.ComponentModel.DataAnnotations;

namespace ProductsCatalog.Application.ViewModels
{
    public class CreateProductModel
    {
        [Required(ErrorMessage = "this field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int CategoryId { get; set; }
    }
}
