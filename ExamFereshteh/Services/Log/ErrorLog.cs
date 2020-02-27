using System;
using System.Globalization;
using System.IO;

namespace ExamFereshteh.Services.Log
{
    public class ErrorLog:ILog
    {
        private readonly string _fullPath = AppDomain.CurrentDomain.BaseDirectory +
                                            "ErrorLog-" + DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";

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