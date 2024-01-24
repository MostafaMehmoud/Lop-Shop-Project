using Lap_Shop_Project.BL;
using Lap_Shop_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
namespace Lap_Shop_Project.Controllers
{
    public class OrderController : Controller
    {
        IItems itemsService;
        public OrderController(IItems itemsservice)
        {
            this.itemsService = itemsservice;
        }
        [Authorize]
        public ActionResult Successed()
        {
            return View();
        }
        public IActionResult MyOrders()
        {
            
            return View();
        }
        
        public IActionResult Cart()
        {
            string sessioncart=string.Empty;
            if (HttpContext.Session.GetString("Cart")!=null)
            {
                sessioncart = HttpContext.Session.GetString("Cart");
            }
                var cart=JsonConvert.DeserializeObject<ShappingCart>(sessioncart);
            return View(cart);
        }
        public IActionResult addtoCart(int id)
        {
            ShappingCart cart;
            if (HttpContext.Session.GetString("Cart") != null)
            {
                cart= JsonConvert.DeserializeObject<ShappingCart>(HttpContext.Session.GetString("Cart"));
            }
            else
            {
                cart= new ShappingCart();
            }
            var item=itemsService.GetById(id);
            var ItemInList=cart.CartItemslist.Where(e=>e.ShoppingCartId==id).FirstOrDefault();
            if (ItemInList!=null)
            {
                ItemInList.Qty++;
                ItemInList.Total=ItemInList.Qty*ItemInList.Price;
            }
            else
            {
                cart.CartItemslist.Add(new ShoppingCartItem
                {
                    ShoppingCartId = item.ItemId,
                    ShoppingCartName = item.ItemName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice
                });
            }
           cart.TotalPrice=cart.CartItemslist.Sum(e=>e.Total);
            HttpContext.Session.SetString("Cart",JsonConvert.SerializeObject(cart));    
            return RedirectToAction("Cart");
        }
    }
}
