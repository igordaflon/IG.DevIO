using System.ComponentModel.DataAnnotations;

namespace IG.DevIO.UI.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id{ get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid SupplierId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Description { get; set; }

        public IFormFile ImageUpload { get; set; }
        public string Image { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Ativo?")]
        public bool IsActive { get; set; }

        public SupplierViewModel Supplier { get; set; }
        public IEnumerable<SupplierViewModel> Suppliers { get; set; }
    }
}
