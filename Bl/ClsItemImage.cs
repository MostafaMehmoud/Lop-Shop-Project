using Lap_Shop_Project.Models;
using System.Collections.Generic;

namespace Lap_Shop_Project.BL
{
    public interface IItemImages
    {
       
        public List<TbItemImage> GetById(int id);
        
    }
    public class ClsItemimage : IItemImages
    {
        LapShopContext context;
        public ClsItemimage(LapShopContext ctx)
        {
            context = ctx;
        }




        public List<TbItemImage> GetById(int id)
        {
            try
            {

                var item = context.TbItemImages.Where(a => a.ItemId == id).ToList();
                return item;
            }
            catch
            {
                return new List<TbItemImage>();
            }
        }
    }  
}
