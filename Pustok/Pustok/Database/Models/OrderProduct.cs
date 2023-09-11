using Pustok.Database.Base;

namespace Pustok.Database.Models
{
    public class OrderProduct : BaseEntity<int>, IAuditable
    {
        public Order Order { get; set; }    
        public int OrderId { get; set; }    
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
