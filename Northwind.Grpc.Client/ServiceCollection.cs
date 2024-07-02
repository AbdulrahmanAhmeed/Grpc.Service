using Grpc.Net.Client.Configuration;
using Grpc.Net.Client;

namespace Northwind.Grpc.Client
{
    public class ServiceCollection
    {
        //public static IServiceCollection AddGrpcServicesClient(this IServiceCollection services)
        //{
        //    services.AddGrpcClient<Greeter.GreeterClient>(client =>
        //    {
        //        client.Address = new Uri("https://localhost:7044");
        //    }).ConfigureChannel(configureChannel => new GrpcChannelOptions
        //    {
        //        ServiceConfig = new ServiceConfig
        //        {
        //            MethodConfigs = { defaultMethodConfig }
        //        }
        //    });
        //    return services;
        //}
    }
}
