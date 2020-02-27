using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace ExamFereshteh.Services.Log
{
    public class DevelopmentLog:ILog
    {
        private readonly string _fullPath = AppDomain.CurrentDomain.BaseDirectory +
                                            "DevelopmentLog-" + DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";

        public void WriteLog(string message)
        {

            using (StreamWriter w = File.AppendText(_fullPath))
            {
                w.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                w.WriteLine("Message:" + message);


            }
        }
    }
}