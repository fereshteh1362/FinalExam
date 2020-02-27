using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExamFereshteh.Models
{
    public class Rate:IRate
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public decimal RateAmount { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
    }
}