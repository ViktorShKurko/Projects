// See https://aka.ms/new-console-template for more information
using Domain.Models;
using Infrastucture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using TestWorkTask.Helpers;
using TestWorkTask.Models;
using WorkTask.Application.Order.Repositories;
using WorkTask.Application.Order.Services;
using WorkTask.DataAccess;
using WorkTask.DataAccess.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        string resource = @"
                            <orders>	
                                <order>
                                    <no>122</no>
                                    <reg_date>2018.01.09</reg_date>
                                    <sum>126065.05</sum>
                                    <product>
                                        <quantity>3</quantity>
                                        <name>Xiomi 12X</name>
                                        <price>42000.75</price>
                                    </product>
                                    <user>
                                        <fio>Петров Виктор Семенович</fio>
                                        <email>xyz@email.com</email>
                                    </user>
                                </order>
                            </orders>";

        var orders = XmlHelper.Deserialize<OrdersModel>(resource);
        Console.WriteLine(orders);

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

        using var serviceProvider = services.BuildServiceProvider();
        var orderService = serviceProvider.GetService<IOrderService>();

        foreach (var order in orders.Orders)
        {
            long d =  orderService.CreateAsync(order, new CancellationToken()).Result;
            Console.WriteLine(d);
        }
    }
}
