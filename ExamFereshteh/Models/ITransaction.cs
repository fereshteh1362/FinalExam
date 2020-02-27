
namespace ExamFereshteh.Models
{
   public interface ITransaction
    {
        int Id { get; set; }
        string Sku { get; set; }
        decimal Amount { get; set; }
        string Currency { get; set; }
    }
}
