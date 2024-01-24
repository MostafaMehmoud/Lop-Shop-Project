using Lap_Shop_Project.Models;

namespace Lap_Shop_Project.BL
{
    public interface IOs
    {
        public List<TbO> GetAll();
        public TbO GetById(int id);
        public bool Save(TbO os);
        public bool Delete(int id);
    }
    public class ClsOs:IOs
    {
        LapShopContext context;
        public ClsOs(LapShopContext ctx) 
        { 
            context = ctx;
        }
        public List<TbO> GetAll()
        {
            try
            { 
            var Listos = context.TbOs.ToList();
                return Listos;
            }
            catch
            {
                return new List<TbO>();
            }
           
        }
        public TbO GetById(int id)
        {
            try
            {
               
                var os = context.TbOs.FirstOrDefault(a => a.OsId == id);
                return os;
            }
            catch
            {
                return new TbO();
            }
        }
        public bool Save(TbO os)
        {
            try
            {
               // os.ImageName = "";
                
                if (os.OsId == 0)
                {
                    os.CurrentState = 1;
                    os.CreatedBy = "1";
                    os.CreatedDate = DateTime.Now;
                    context.TbOs.Add(os);
                }
                else
                {
                    os.UpdatedDate = DateTime.Now;
                    os.UpdatedBy = "1";
                    context.Entry(os).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                
                var os=GetById(id);
                context.TbOs.Remove(os);
                os.CurrentState = 0;
                context.SaveChanges();
                return true;
            }catch
            { 
                return false;
            }
        }
    }
}
