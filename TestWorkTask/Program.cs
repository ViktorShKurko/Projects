// See https://aka.ms/new-console-template for more information
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TestWorkTask.Configurer;
using TestWorkTask.Helpers;
using TestWorkTask.Models;
using WorkTask.Application.Order.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        // путь к файлу с загружаемыми данными
        string path = Path.Combine(Directory.GetCurrentDirectory(), @"TestDataRes\TestData.xml");

        if (!File.Exists(path)) 
        {
            Console.WriteLine("file not found");
            return;
        }

        // string data = File.ReadAllText(path);
        string data = File.ReadAllText(path);

        var orders = XmlHelper.Deserialize<OrdersModel>(data);
        Console.WriteLine(orders);

        var servicesProvider = ServiceConfiguration.Build();
        var orderService = servicesProvider.GetService<IOrderService>();

        // НЕ работает с дубликатами
        //var sw = new Stopwatch();
        //sw.Start();
        //var d = orderService.CreateOrdersAsync(orders.Orders).Result;
        //sw.Stop();
        //Console.WriteLine(sw.Elapsed);

        var sw1 = new Stopwatch();
        sw1.Start();
        foreach (var order in orders.Orders)
        {
            long createdOrderId = orderService.CreateOrUpdateAsync(order, new CancellationToken()).Result;
        }
        sw1.Stop();
        Console.WriteLine(sw1.Elapsed);
    }
}
