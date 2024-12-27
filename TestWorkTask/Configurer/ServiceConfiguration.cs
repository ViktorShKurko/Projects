using Infrastucture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkTask.Application.Order.Repositories;
using WorkTask.Application.Order.Services;
using WorkTask.DataAccess.Repositories;
using WorkTask.DataAccess;
using Microsoft.EntityFrameworkCore;
using WorkTask.AppServices.User.Repositories;
using WorkTask.AppServices.Product.Repositories;
using Microsoft.Extensions.Logging;

namespace TestWorkTask.Configurer
{
    public class ServiceConfiguration
    {
        public static IServiceProvider Build() 
        {
            // TODO: Вынести логику с получением строки подключения, вывести в отдельный проект чтоб убрать множество зависимостей с хостового проекта
            var configuration = new ConfigurationBuilder();
            var path = Directory.GetCurrentDirectory();
            configuration.SetBasePath(Directory.GetCurrentDirectory());
            configuration.AddJsonFile("appsettings.json");
            var config = configuration.Build();
            var connectionString = config.GetConnectionString("SecondConnection");
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<WorkTaskDbContext>(options => options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();

            return services.BuildServiceProvider();
        }
    }
}
