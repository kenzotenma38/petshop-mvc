using System.ComponentModel.DataAnnotations;

namespace Petshop.MVC.Models
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        public required string Password {  get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public required string ConfirmPassword { get; set; }
        
        public required string Email {  get; set; }
        public required string ResetPasswordToken {  get; set; }
    }
}
