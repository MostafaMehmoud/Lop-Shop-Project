namespace Lap_Shop_Project.Models
{
    public class VmItemDetails
    {
        public VmItemDetails() 
        {
            vwItem=new VwItem();
            imageList = new List<TbItemImage>();
            vwRecommenendItemlist = new List<VwItem>();
        }
        public VwItem vwItem { get; set; }
        public List<TbItemImage> imageList { get; set; }
        public List<VwItem> vwRecommenendItemlist {  get; set; }
    }
}
