namespace Lap_Shop_Project.Models
{
    public class ShappingCart
    {
        public ShappingCart() 
        {
            CartItemslist = new List<ShoppingCartItem>();
        }
        public List<ShoppingCartItem> CartItemslist { get; set; }
        public decimal TotalPrice {  get; set; }
        public string Promocode {  get; set; }
    }
}
