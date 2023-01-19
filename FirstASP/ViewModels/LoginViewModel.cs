using System.ComponentModel.DataAnnotations;
namespace FirstASP.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name ="Username")]
        [Required(ErrorMessage ="Must enter a username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
