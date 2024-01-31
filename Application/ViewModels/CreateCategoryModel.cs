using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ProductsCatalog.Application.ViewModels
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage = "this fied is required")]
        public string? Name { get; set; } 
    }
}
