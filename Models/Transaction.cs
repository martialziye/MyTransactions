using System.ComponentModel.DataAnnotations;
namespace MyTransactions.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        public decimal Montant { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [RegularExpression("^(dépôt|retrait)$", ErrorMessage = "Type must be 'dépôt' or 'retrait'")]
        public string? Type { get; set; }
    }
}
