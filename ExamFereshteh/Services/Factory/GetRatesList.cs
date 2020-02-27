using ExamFereshteh.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ExamFereshteh.Services.Factory
{
    public class GetRatesList:IGateRatesList
    {
        public List<Rate> RatesList { get; set; }
        private rates _rates;
        public void GetListOfRates()
        {
            _rates = new rates();
            var path = @"http://quiet-stone-2094.herokuapp.com/rates.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(rates));
            using (StreamReader reader = new StreamReader(path))
            {
                _rates = (rates)serializer.Deserialize(reader);
            }
            foreach (var i in _rates.rate)
            {
                RatesList.Add(new Rate()
                {
                    RateAmount = i.rate,
                    From = i.from,
                    To = i.to
                });
            }



        }
    }
}