// See https://aka.ms/new-console-template for more information
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TestWorkTask.Configurer;
using TestWorkTask.Helpers;
using TestWorkTask.Models;
using WorkTask.Application.Order.Services;
using WorkTask.AppServices.Handlers;

internal class Program
{
    private static async Task Main(string[] args)
    {

        // путь к файлу с загружаемыми данными
        string path = Path.Combine(Directory.GetCurrentDirectory(), @"TestDataRes\Data100.xml");

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

        var orderHandler = servicesProvider.GetService<Handler<OrderModel>>();

        await orderHandler.ProcessFileAsync(path);

        //var orderService = servicesProvider.GetService<IOrderService>();

        //var sw = new Stopwatch();
        //sw.Start();
        //await orderService.CreateOrdersWithBulkAsync(orders.Orders);
        ////var d = await orderService.CreateOrdersAsync(orders.Orders);
        //sw.Stop();
        //Console.WriteLine(sw.Elapsed);

        //var sw1 = new Stopwatch();
        //sw1.Start();
        //foreach (var order in orders.Orders)
        //{
        //    long createdOrderId = orderService.CreateOrUpdateAsync(order, new CancellationToken()).Result;
        //}
        //sw1.Stop();
        //Console.WriteLine(sw1.Elapsed);
    }
}
