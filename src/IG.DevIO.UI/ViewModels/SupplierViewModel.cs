using System.ComponentModel.DataAnnotations;

namespace IG.DevIO.UI.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Document { get; set; }

        [Display(Name = "Tipo")]
        public int SupplierType { get; set; }

        public AddressViewModel Address { get; set; }

        [Display(Name = "Ativo?")]
        public bool IsActive { get; set; }

        //public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
