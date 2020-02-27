using ExamFereshteh.Services.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Polly;

namespace ExamFereshteh.Services.ConnectionManager
{
    public class ConnectionWebManager
    {
        public async Task<bool> IsOkConnection()
        {
            var developmentLog = new DevelopmentLog();
            var errorLog = new ErrorLog();

            var httpClient = new HttpClient();
            var response = await Policy
                .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2),
                    (result, timeSpan, retryCount, context) =>
                    {
                        developmentLog.WriteLog(
                            $"Request failed with {result.Result.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}");
                    })
                .ExecuteAsync(() => httpClient.GetAsync(@"https://webbasketapi.azurewebsites.net/api/jugadores.xml"));

            if (response.IsSuccessStatusCode)
            {
                developmentLog.WriteLog("Response was successful.");
            }
            else
            {
                errorLog.WriteLog($"Response failed. Status code {response.StatusCode}");
            }

            return response.IsSuccessStatusCode;
        }
    }
}