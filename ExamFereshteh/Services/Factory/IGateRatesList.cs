using ExamFereshteh.Models;
using System.Collections.Generic;


namespace ExamFereshteh.Services.Factory
{
   public interface IGateRatesList
    {
        List<Rate> RatesList { get; set; }
        void GetListOfRates();
    }
}
