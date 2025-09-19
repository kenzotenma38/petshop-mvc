using System.ComponentModel.DataAnnotations;

namespace Petshop.MVC.Models
{
    public class LoginViewModel
    {
        public required string Username { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        public string? ReturnUrl {  get; set; }
        public bool RememberMe { get; set; }
    }
}
