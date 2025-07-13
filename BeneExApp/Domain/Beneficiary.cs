using System.ComponentModel.DataAnnotations;

namespace BeneExApp.Domain
{
    public class Beneficiary
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(15)]
        public string MobileNo { get; set; }

        [MaxLength(15)]
        public string PhoneNo { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string BankName { get; set; }

        [MaxLength(100)]
        public string BranchName { get; set; }

        [MaxLength(20)]
        public string AccountNo { get; set; }

        [MaxLength(15)]
        public string IFSCCode { get; set; }

        [MaxLength(10)]
        public string PANNo { get; set; }

        [MaxLength(15)]
        public string GSTNo { get; set; }

        public ICollection<Expenditure> Expenditures { get; set; }
    }
}
