using Lap_Shop_Project.Models;

namespace Lap_Shop_Project.BL
{
    public interface IItemType
    {
        public List<TbItemType> GetAll();
        public TbItemType GetById(int id);
        public bool Save(TbItemType itemTypes);
        public bool Delete(int id);
    }
    public class ClsItemType:IItemType
    {
        LapShopContext context;
        public ClsItemType(LapShopContext ctx) 
        {
            context=ctx;
        }
        public List<TbItemType> GetAll()
        {
            try
            {
            var ListItemTypes = context.TbItemTypes.ToList();
                return ListItemTypes;
            }
            catch
            {
                return new List<TbItemType>();
            }
           
        }
        public TbItemType GetById(int id)
        {
            try
            {
                LapShopContext context = new LapShopContext();
                var itemTypes = context.TbItemTypes.FirstOrDefault(a => a.ItemTypeId == id);
                return itemTypes;
            }
            catch
            {
                return new TbItemType();
            }
        }
        public bool Save(TbItemType itemTypes)
        {
            try
            {
               // itemTypes.ImageName = "";
                LapShopContext context = new LapShopContext();
                if (itemTypes.ItemTypeId == 0)
                {
                    itemTypes.CurrentState = 1;
                    itemTypes.CreatedBy = "1";
                    itemTypes.CreatedDate = DateTime.Now;
                    context.TbItemTypes.Add(itemTypes);
                }
                else
                {
                    itemTypes.UpdatedDate = DateTime.Now;
                    itemTypes.UpdatedBy = "1";
                    context.Entry(itemTypes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                context.SaveChanges();
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
                LapShopContext context = new LapShopContext();
                var itemTypes=GetById(id);
                context.TbItemTypes.Remove(itemTypes);
                itemTypes.CurrentState = 0;
                context.SaveChanges();
                return true;
            }catch
            { 
                return false;
            }
        }
    }
}
