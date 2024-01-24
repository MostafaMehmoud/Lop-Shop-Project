namespace Lap_Shop_Project.Models
{
    public class ShoppingCartItem
    {
        
        public int ShoppingCartId { get; set; }
        public string ShoppingCartName { get; set; }
        public string ShoppingCartImage { get; set; }
        public int Qty {  get; set; }
        public decimal Price {  get; set; }
        public decimal Total {  get; set; }
    }
}
