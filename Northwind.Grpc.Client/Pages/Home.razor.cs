using Grpc.Net.ClientFactory;
using Microsoft.AspNetCore.Components;
using Northwind.Grpc.Client.Models;
using Northwind.Grpc.Client.Services;
using System.Xml.Linq;

namespace Northwind.Grpc.Client.Pages
{
    public partial class Home
    {
        HomeIndexViewModel model = new();
        [Inject] ILogger<Home> logger { get; set; }
        [Inject] GreetingServies _greetingServies {  get; set; }
        //public Home(GrpcClientFactory factory,ILogger<Home> logger) {
        //    _logger = logger;
        //    _greeterClient = factory.CreateClient<Greeter.GreeterClient>("Greeter");
        //}
        protected override async Task OnInitializedAsync()
        {
            string name = "Henrietta";
            //HomeIndexViewModel model = new ();
            try
            {
                var reply = await _greetingServies.GetGreeter();
                model.Greeting = "Greeting from gRPC service: " + reply.Message;
            }
            catch (Exception ex)
            {
                logger.LogWarning($"Northwind.Grpc.Service is not responding.");
                model.ErrorMessage = ex.Message;
            }
        }
    }
}
