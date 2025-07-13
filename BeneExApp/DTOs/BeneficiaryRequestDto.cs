using BeneExApp.Domain;
using System.ComponentModel.DataAnnotations;

namespace BeneExApp.DTOs
{
    public class BeneficiaryRequestDto
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, RegularExpression(@"^[a-zA-Z0-9._]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Phone, StringLength(10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter a valid 10-digit mobile number.")]
        public string MobileNo { get; set; }
        
        [Phone, StringLength(10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter a valid 10-digit phone number.")]
        public string PhoneNo { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        public string BranchName { get; set; }

        [Required, RegularExpression(@"^\d{9,18}$", ErrorMessage = "Enter a valid bank account number."), StringLength(18)]
        public string AccountNo { get; set; }

        [Required, RegularExpression("^[A-Z]{4}0[A-Z0-9]{6}$", ErrorMessage = "Invalid IFSC Code format"), StringLength(11)]
        public string IFSCCode { get; set; }

        [Required, RegularExpression("^[A-Z]{5}[0-9]{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN number format (ABCDE1234F)"), StringLength(10)]
        public string PANNo { get; set; }

        [Required, RegularExpression("^\\d{2}[A-Z]{5}\\d{4}[A-Z]{1}[A-Z\\d]{1}Z[A-Z\\d]{1}$", ErrorMessage = "Invalid GST number format (11AAAAA1111A1Z1)"), StringLength(15)]
        public string GSTNo { get; set; }

        public ICollection<Expenditure>? Expenditures { get; set; }
    }
}