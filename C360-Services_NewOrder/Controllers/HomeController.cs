using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C360_Services_NewOrder.Models;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace C360_Services_NewOrder.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _iconfiguration;
        public SQS_Consumer _client;
        public AppConfig _appConfig = null;
         
        public HomeController(IConfiguration configuration )
        {
            _iconfiguration = configuration;
            _appConfig = new AppConfig();
            _appConfig.AwsAccessKey = _iconfiguration["AwsAccessKey"];
            _appConfig.AwsSecretKey = _iconfiguration["AwsSecretKey"];



            _client = new SQS_Consumer(_appConfig);
        }
        public async Task<IActionResult> Index()
        {
            //_appConfig = new AppConfig();
            //_appConfig.AwsAccessKey = _iconfiguration["AwsAccessKey"];
            //_appConfig.AwsSecretKey = _iconfiguration["AwsSecretKey"];

            

            //_client = new SQS_Consumer(_appConfig);

            ////Send Sample message to Queue
            //await _client.SendMessagetoSQS();

            ////Get Message from Queue
            //// Define the cancellation token.
            //CancellationTokenSource source = new CancellationTokenSource();
            //CancellationToken token = source.Token;
            //await _client.GetMessagesAsync("NewOrder",token);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async void SendRequest(object sender, EventArgs e)
        {
            //Send Sample message to Queue
            await _client.SendMessagetoSQS();
            return;
        }

        public async void GetRequest()
        {
            //Get Message from Queue
            // Define the cancellation token.
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            await _client.GetMessagesAsync("NewOrder", token);
            return;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
