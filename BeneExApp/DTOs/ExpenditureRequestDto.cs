using BeneExApp.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeneExApp.DTOs
{
    public class ExpenditureRequestDto
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Financial Year")]
        public string FinancialYear { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Code")]
        public string ProjectCode { get; set; }

        [Display(Name = "Project Detail")]
        public string ProjectDetail { get; set; }

        [Required]
        [Display(Name = "Beneficiary")]
        public int BeneficiaryId { get; set; }

        public IEnumerable<SelectListItem>? Beneficiaries { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        [Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Deduction Amount")]
        [Range(0, double.MaxValue)]
        public decimal DeductionAmount { get; set; }

        [Display(Name = "Net Amount")]
        public decimal NetAmount => TotalAmount - DeductionAmount;

        public string Remarks { get; set; }

        public Beneficiary? Beneficiary { get; set; }
    }
}