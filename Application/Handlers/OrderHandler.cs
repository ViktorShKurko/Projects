using FluentValidation;
using System.Collections;
using System.Diagnostics;
using TestWorkTask.Helpers;
using TestWorkTask.Models;
using WorkTask.Application.Order.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkTask.AppServices.Handlers
{
    /// <summary>
    /// Обработчик данных о заказах
    /// </summary>
    public class OrderHandler: Handler<OrderModel>
    {
        private readonly IOrderService _orderService;
        private readonly IValidator<OrderModel> _validator;

        public OrderHandler(IOrderService orderService, IValidator<OrderModel> validator)
        {
            _orderService = orderService;
            _validator = validator;
        }

        public override async Task ProcessFileAsync(string filePath)
        {
            string dataFromFile = ReadFile(filePath);
            var orderData = XmlHelper.Deserialize<OrdersModel>(dataFromFile);
            ValidateData(orderData.Orders);

            var sw1 = new Stopwatch();
            sw1.Start();
            await UseBulkLoadAsync(orderData.Orders);
            sw1.Stop();
            Console.WriteLine($"Время выполнения запроса: {sw1.Elapsed}");
        }

        // Standart Update with Add
        private async Task UseStandartCreateOrUpdateRangeAsync(ICollection<OrderModel> orderModels) 
        {
            await _orderService.CreateOrdersAsync(orderModels);
        }

        //  EFCore.BulkExtensions.
        private async Task UseBulkLoadAsync(ICollection<OrderModel> orderModels) 
        {
            await _orderService.CreateOrdersWithBulkAsync(orderModels);
        }

        // Standart UpdateRange with AddRange
        private async Task UseStandartCreateOrUpdateAsync(ICollection<OrderModel> orderModels) 
        {
            foreach (var order in orderModels)
            {
                await _orderService.CreateOrUpdateAsync(order, new CancellationToken());
            }
        }

        protected override void ValidateData(ICollection<OrderModel> orders) 
        {
            var errors = new List<string>();
            foreach (var item in orders)
            {
                var result = _validator.Validate(item);
                if (!result.IsValid)
                    errors.AddRange(result.Errors.Select(x=> x.ErrorMessage));
            }

            if (errors.Any())
                throw new ValidationException($"Ошибки валидации: {string.Join(", ", errors)}");
        }
    }
}
