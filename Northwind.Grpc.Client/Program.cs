using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Northwind.Grpc.Client;
using Northwind.Grpc.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);



builder.Services.AddSingleton<GreetingServies>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddGrpcClient<Greeter.GreeterClient>("Greeter", options =>
{
    options.Address = new Uri("https://localhost:5131");
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
    return handler;
});

await builder.Build().RunAsync();
