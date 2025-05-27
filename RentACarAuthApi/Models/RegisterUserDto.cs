using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required, DataType(DataType.Password), MinLength(6)]
        public string? Password { get; set; }
    }
}
