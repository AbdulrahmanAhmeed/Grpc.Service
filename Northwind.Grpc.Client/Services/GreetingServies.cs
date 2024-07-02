using Grpc.Net.Client;
using Grpc.Net.ClientFactory;
using Northwind.Grpc.Client.Models;

namespace Northwind.Grpc.Client.Services
{
    public class GreetingServies
    {
        private readonly ILogger<GreetingServies> _logger;
        private readonly Greeter.GreeterClient _greeterClient;
        


        public GreetingServies(ILogger<GreetingServies> logger, Greeter.GreeterClient factory)
        {
            
            _greeterClient = factory;
            _logger = logger;
        }

        public async Task<HelloReply> GetGreeter(string name = "Henrietta")
        {
            HelloReply reply = new();
            try
            {
                
                reply = await _greeterClient.SayHelloAsync(new HelloRequest { Name = name });
                //model.Greeting = "Greeting from gRPC service: " + reply.Message;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Northwind.Grpc.Service is not responding.");
                //model.ErrorMessage = ex.Message;
            }
            return reply;

        }
    }
}
