namespace Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; } 
    }
}
