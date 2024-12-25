using Infrastucture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkTask.Application.Order.Repositories;
using WorkTask.Application.Order.Services;
using WorkTask.DataAccess.Repositories;
using WorkTask.DataAccess;
using Microsoft.EntityFrameworkCore;

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

            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<WorkTaskDbContext>(options => options.UseSqlServer(config.GetConnectionString("SecondConnection")));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();

            return services.BuildServiceProvider();
        }
    }
}
