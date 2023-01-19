using System.ComponentModel.DataAnnotations;

namespace FirstASP.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
       
        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="you must enter an email address")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string? Phone { get; set; }
    }
}
