using Lap_Shop_Project.Models;

namespace Lap_Shop_Project.BL
{
    public interface ISlider
    {
        public List<TbSlider> GetAll();
        public TbSlider GetById(int id);
        public bool Save(TbSlider slider);
        public bool Delete(int id);
    }
    public class ClsSlider : ISlider
    {
        LapShopContext context;
        public ClsSlider(LapShopContext ctx) 
        {
            context=ctx;
        }
        public List<TbSlider> GetAll()
        {
            try
            {
            var ListSlider = context.TbSliders.ToList();
                return ListSlider;
            }
            catch
            {
                return new List<TbSlider>();
            }
           
        }
        public TbSlider GetById(int id)
        {
            try
            {
                LapShopContext context = new LapShopContext();
                var slider = context.TbSliders.FirstOrDefault(a => a.SliderId == id);
                return slider;
            }
            catch
            {
                return new TbSlider();
            }
        }
        public bool Save(TbSlider slider)
        {
            try
            {
               // slider.ImageName = "";
                LapShopContext context = new LapShopContext();
                if (slider.SliderId == 0)
                {
                    
                    slider.CreatedBy = "1";
                    slider.CreatedDate = DateTime.Now;
                    context.TbSliders.Add(slider);
                }
                else
                {
                    slider.UpdatedDate = DateTime.Now;
                    slider.UpdatedBy = "1";
                    context.Entry(slider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var slider=GetById(id);
                context.TbSliders.Remove(slider);
               
                context.SaveChanges();
                return true;
            }catch
            { 
                return false;
            }
        }
    }
}
