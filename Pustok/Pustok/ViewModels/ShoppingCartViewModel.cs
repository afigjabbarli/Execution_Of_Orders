using Pustok.Database.Models;

namespace Pustok.ViewModels
{
    public class ShoppingCartViewModel
    {
        public string Product_Name { get; set; }    
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }   
        public string Tracking_Code { get; set; }
        public decimal Total_Price { get; set; }    
         
    }
}
