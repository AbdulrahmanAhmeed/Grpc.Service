using Grpc.Net.ClientFactory;
using Microsoft.AspNetCore.Mvc;
using Northwind.Grpc.Client.MVC.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace Northwind.Grpc.Client.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Greeter.GreeterClient _greeterClient;


        public HomeController(ILogger<HomeController> logger,GrpcClientFactory factory )
        {
            _logger = logger;
            _greeterClient = factory.CreateClient<Greeter.GreeterClient>("Greeter");
        }

        public async Task<IActionResult> Index(string name = "Henrietta")
        {
            HomeIndexViewModel model = new();
            try
            {
                HelloReply reply = await _greeterClient.SayHelloAsync(new HelloRequest { Name = name });
                model.Greeting = "Greeting from gRPC service: " + reply.Message;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Northwind.Grpc.Service is not responding.");
                model.ErrorMessage = ex.Message;
            }
            return View(model);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
