using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeneExApp.Domain
{
    public class Expenditure
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string FinancialYear { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, MaxLength(150)]
        public string ProjectName { get; set; }

        [Required, MaxLength(50)]
        public string ProjectCode { get; set; }

        [MaxLength(300)]
        public string ProjectDetail { get; set; }

        [Required]
        public int BeneficiaryId { get; set; }

        [ForeignKey("BeneficiaryId")]
        public Beneficiary Beneficiary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeductionAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetAmount { get; set; }

        [MaxLength(300)]
        public string Remarks { get; set; }
    }
}