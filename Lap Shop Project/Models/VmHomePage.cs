namespace Lap_Shop_Project.Models
{
    public class VmHomePage
    {
        public VmHomePage() 
        {
            listAllItems = new List<VwItem>();
            listRecommendedItems=new List<VwItem>();
            listNewItems=new List<VwItem>();
            ListFreeDelivary=new List<VwItem>();
            listCategories=new List<TbCategory>();
            Listslider=new List<TbSlider>();

        }
        public List<VwItem> listAllItems { get; set; }
        public List<VwItem> listRecommendedItems { get;set; }
        public List<VwItem> listNewItems { get; set; }
        public List<VwItem> ListFreeDelivary {  get; set; }
        public List<TbCategory> listCategories { get; set; }    
        public List<TbSlider> Listslider = new List<TbSlider>();    

    }
}
