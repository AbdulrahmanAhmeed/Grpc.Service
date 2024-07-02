namespace Northwind.Grpc.Service.Services
{
    public static class CORSConfigurations
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "Northwind.Mvc.Policy",
                  policy =>
                  {
                      policy.WithOrigins("https://localhost:5133");
                  });
            });
            return services;
        }
    }
}
