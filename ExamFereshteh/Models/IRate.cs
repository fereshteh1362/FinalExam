namespace ExamFereshteh.Models
{
    public interface IRate
    {
        int Id { get; set; }
        decimal RateAmount { get; set; }
        string From { get; set; }
        string To { get; set; }
    }
}