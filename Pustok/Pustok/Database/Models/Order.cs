using Pustok.Database.Base;

namespace Pustok.Database.Models
{
    public class Order : BaseEntity<int>, IAuditable
    {
        public string Key { get; set; } 
        public string OrderStatus { get; set; } 
        public User User { get; set; }
        public int User_ID { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
