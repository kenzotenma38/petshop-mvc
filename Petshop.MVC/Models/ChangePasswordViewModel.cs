using System.ComponentModel.DataAnnotations;

namespace Petshop.MVC.Models
{
    public class ChangePasswordViewModel
    {
        public required string CurrentPassword {  get; set; }

        [DataType(DataType.Password)]
        public required string NewPassword {  get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public required string ConfirmPassword { get; set; }
    }
}
