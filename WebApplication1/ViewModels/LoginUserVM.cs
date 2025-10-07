using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class LoginUserVM
    {
        [Required(ErrorMessage ="*")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="*")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
