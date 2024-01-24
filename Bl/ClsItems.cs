using Lap_Shop_Project.Models;
using System.Collections.Generic;


namespace Lap_Shop_Project.BL
{
    public interface IItems
    {
        public List<TbItem> GetAll();
        public TbItem GetById(int id);
        public List<VwItem> GetAllItems(int? id);
        public List<VwItem> GetRecommenendItems(int id);
        public bool Save(TbItem item);
        public bool Delete(int id);
        public VwItem GetItemById(int id);

    }
    public class ClsItems:IItems
    {
        LapShopContext context;
        public ClsItems(LapShopContext ctx) 
        {
            context=ctx;
        }
       
        

        public List<TbItem> GetAll()
        {
            try
            {
                
                var ListItems = context.TbItems.ToList();
                return ListItems;
            }
            catch
            {
                return new List<TbItem>();
            }

        }
        public TbItem GetById(int id)
        {
            try
            {

                var item = context.TbItems.FirstOrDefault(a => a.ItemId == id );
                return item;
            }
            catch
            {
                return new TbItem();
            }
        }
        public VwItem GetItemById(int id)
        {
            try
            {

                var item = context.VwItems.FirstOrDefault(a => a.ItemId == id );
                return item;
            }
            catch
            {
                return new VwItem();
            }
        }
        public List<VwItem> GetAllItems(int? id) 
        {

            
            List<VwItem> items = context.VwItems.Where(e=>(e.CategoryId==id|| id==null || id==0) &&!string.IsNullOrEmpty(e.ItemName)).OrderByDescending(e=>e.CreatedDate).ToList();
            return items;
        }
        public bool Save(TbItem item)
        {
            try
            {
                // item.ImageName = "";
                
                if (item.ItemId == 0)
                {
                    item.CurrentState = 1;
                    item.CreatedBy = "1";
                    item.CreatedDate = DateTime.Now;
                    context.TbItems.Add(item);
                    context.SaveChanges();
                }
                else
                {
                    item.UpdatedDate = DateTime.Now;
                    item.UpdatedBy = "1";
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }

                
                return true;

            }
            catch
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                
                var item = GetById(id);
                context.TbItems.Remove(item);
                item.CurrentState=0;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<VwItem> GetRecommenendItems(int id)
        {
            try
            {   var item= GetById(id);
                var recommenendItems=context.VwItems.Where(e=>e.SalesPrice>item.SalesPrice-50&&e.SalesPrice<item.SalesPrice+50).OrderByDescending(e=>e.CreatedDate).ToList();
                return recommenendItems;
            }
            catch
            {
                return new List<VwItem>();
            }

            }
          
    }
}
