using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o seu nome")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Usuário")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
