using Lap_Shop_Project.Models;

namespace Lap_Shop_Project.BL;

public interface ICategory
{
    public List<TbCategory> GetAll();
    public TbCategory GetById(int id);
    public bool Save(TbCategory category);
    public bool Delete(int id);

}
public class ClsCategories:ICategory
{
    LapShopContext context;
    public ClsCategories(LapShopContext ctx) 
    { 
        context = ctx;
    }
    public List<TbCategory> GetAll()
    {
        try
        { 
        var ListCategories = context.TbCategories.ToList();
            return ListCategories;
        }
        catch
        {
            return new List<TbCategory>();
        }
       
    }
    public TbCategory GetById(int id)
    {
        try
        {
           
            var category = context.TbCategories.FirstOrDefault(a => a.CategoryId == id );
            return category;
        }
        catch
        {
            return new TbCategory();
        }
    }
    public bool Save(TbCategory category)
    {
        try
        {
           // category.ImageName = "";
           
            if (category.CategoryId == 0)
            {
                category.CurrentState = 1;
                category.CreatedBy = "1";
                category.CreatedDate = DateTime.Now;
                context.TbCategories.Add(category);
            }
            else
            {
                category.UpdatedDate = DateTime.Now;
                category.UpdatedBy = "1";
                context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
           
            var category=GetById(id);
            context.TbCategories.Remove(category);
            category.CurrentState = 0;
            context.SaveChanges();
            return true;
        }catch
        { 
            return false;
        }
    }
}
