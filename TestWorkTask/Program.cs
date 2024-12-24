// See https://aka.ms/new-console-template for more information
using Infrastucture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestWorkTask.Configurer;
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

        var servicesProvider = ServiceConfiguration.Build();
        var orderService = servicesProvider.GetService<IOrderService>();

        foreach (var order in orders.Orders)
        {
            long createdOrderId =  orderService.CreateAsync(order, new CancellationToken()).Result;
            Console.WriteLine(createdOrderId);
        }
    }
}
