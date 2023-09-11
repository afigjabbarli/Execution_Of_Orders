using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Database;
using Pustok.Migrations;
using Pustok.Services.Abstracts;

using Pustok.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace Pustok.Controllers
{
    public class OrderController : Controller
    {

        private readonly IUserService _userService;
        private readonly PustokDbContext _DbContext;
        public OrderController(IUserService userService, PustokDbContext pustokDbContext)
        {
            _userService = userService;
            _DbContext = pustokDbContext;
        }
        [HttpGet]
        public IActionResult ShoppingCart()
        {
            var CartItems = new List<ShoppingCartViewModel>();
            var basket = _DbContext.Baskets.SingleOrDefault(b => b.UserId == _userService.CurrentUser.Id);
            if (basket == null)
            {
                NotFound();
            }
            var basketItems = _DbContext.BasketItems.Where(bi => bi.BasketId == basket.Id).ToList();
            foreach (var basketItem in basketItems)
            {
                basketItem.Product = _DbContext.BasketItems.Select(bi => bi.Product).Where(bi => basketItem.ProductId == bi.Id).FirstOrDefault();
                if(CartItems.Exists(ci => ci.Tracking_Code == basketItem.Product.TrackingCode))
                {
                    var cartItem = CartItems.FirstOrDefault(ci => ci.Tracking_Code == basketItem.Product.TrackingCode);
                    cartItem.Quantity += 1;
                }
                else
                {
                    CartItems.Add(new ShoppingCartViewModel
                    {
                        Product_Name = basketItem.Product.Name, 
                        Quantity = basketItem.Quantity, 
                        Price = basketItem.Product.Price,
                        Tracking_Code = basketItem.Product.TrackingCode,
                        ImageUrl = basketItem.Product.PhysicalImageName,
                        Total_Price = basketItem.Product.Price * basketItem.Quantity

                    });
                }
            }
            //foreach (var basketItem in basketItems)
            //{
            //    basketItem.Product = _DbContext.BasketItems.Select(bi => bi.Product).Where(bi => basketItem.ProductId == bi.Id).FirstOrDefault();

            //}

            //foreach (var basketItem in basketItems)
            //{

            //    var existingItem = CartItems.FirstOrDefault
            //        (ci => ci.Tracking_Code == basketItem.Product.TrackingCode);

            //    if (existingItem != null)
            //    {
            //        existingItem.Quantity++;
            //    }
            //    else
            //    {
            //        var resultQuantity = 0;
            //        resultQuantity += basketItem.Quantity;

            //        CartItems.Add(new ShoppingCartViewModel
            //        {
            //            Product_Name = basketItem.Product.Name,
            //            Price = basketItem.Product.Price,
            //            Total_Price = basketItem.Product.Price * basketItem.Quantity,
            //            ImageUrl = basketItem.Product.PhysicalImageName,
            //            Tracking_Code = basketItem.Product.TrackingCode,
            //            Quantity = basketItem.Quantity,


            //        });
            //    }
            //}
            return View(CartItems);

        }
        

    }
}
