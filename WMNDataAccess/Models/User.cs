using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMNDataAccess.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string EmailID { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "Password must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$",
            ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
#nullable enable
        public string? MiddleName { get; set; }

        [MaxLength(50)]
#nullable enable
        public string? LastName { get; set; }

#nullable enable
        public Gender? Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
#nullable enable
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
#nullable enable
        public string? PhoneNumber { get; set; }

        [NotMapped]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Please agree to Terms of Service")]
        public bool TermsOfService { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Others
    }

    public class Login
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string EmailID { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "Password must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$",
            ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; } = null!;

    }
}
