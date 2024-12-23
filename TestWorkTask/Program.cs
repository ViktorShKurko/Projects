// See https://aka.ms/new-console-template for more information
using Infrastucture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        string resource = @"<orders>
                        <order>
                            <no>1</no>
                            <reg_date>2012.12.19</reg_date>
                            <sum>234022.25</sum>
                            <product>
                                <quantity>2</quantity>
                                <name>LG 1755</name>
                                <price>12000.75</price>
                            </product>
                            <product>
                                <quantity>5</quantity>
                                <name>Xiomi 12X</name>
                                <price>42000.75</price>
                            </product>
                            <product>
                                <quantity>10</quantity>
                                <name>Noname 14232</name>
                                <price>1.7</price>
                            </product>
                            <user>
                                <fio>Иванов Иван Иванович</fio>
                                <email>abc@email.com</email>
                            </user>
                        </order>
                        <order>
                            <no>122</no>
                            <reg_date>2018.01.09</reg_date>
                            <sum>126065.05</sum>
                            <product>
                                <quantity>3</quantity>
                                <name>Xiomi 12X</name>
                                <price>42000.75</price>
                            </product>
                            <product>
                                <quantity>20</quantity>
                                <name>Noname 222</name>
                                <price>3.14</price>
                            </product>
                            <user>
                                <fio>Петров Виктор Семенович</fio>
                                <email>xyz@email.com</email>
                            </user>
                        </order>
                </orders>";
        var configuration = new ConfigurationBuilder();
        var path = Directory.GetCurrentDirectory();
        configuration.SetBasePath(Directory.GetCurrentDirectory());
        configuration.AddJsonFile("appsettings.json");
        var config = configuration.Build();

        var orders = XmlDeserializeHelper.GetModel<OrdersModel>(resource);
        Console.WriteLine(orders);

        IServiceCollection services = new ServiceCollection();
        var optionsBuilder = new DbContextOptionsBuilder();
        //var options = optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection")).Options;
        services.AddDbContext<WorkTaskDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
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


//services.AddDbContext<WorkTaskDbContext>();
//services.AddTransient<IRepository, Repository>();




//var order = XmlDeserializeHelper.GetModel<OrdersModel>(resource);
//Console.WriteLine(order);





