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
        string path = Path.Combine(Directory.GetCurrentDirectory(), @"TestDataRes\TestData.xml");

        if (!File.Exists(path)) 
        {
            Console.WriteLine("file not found");
            return;
        }

        // string data = File.ReadAllText(path);
        string data = File.ReadAllText(path);

        var orders = XmlHelper.Deserialize<OrderModel>(data);
        Console.WriteLine(orders);

        var servicesProvider = ServiceConfiguration.Build();
        var orderService = servicesProvider.GetService<IOrderService>();

        var sw = new Stopwatch();
        sw.Start();

        long createdOrderId = orderService.CreateOrUpdateAsync(orders, new CancellationToken()).Result;
        //var d = orderService.CreateOrdersAsync(orders.Orders).Result;
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
        //foreach (var order in orders.Orders)
        //{
        //    long createdOrderId = orderService.CreateAsync(order, new CancellationToken()).Result;

        //    Console.WriteLine(createdOrderId);
        //}
    }
}
