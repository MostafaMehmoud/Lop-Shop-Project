using Microsoft.AspNetCore.Mvc;
using Lap_Shop_Project.BL;
using Lap_Shop_Project.Models;
namespace Lap_Shop_Project.Areas.Admin.Controllers
{
     
    public class SliderController : Controller
    {
        ISlider oslider;
        public SliderController(ISlider clsSlider) 
        {
            oslider=clsSlider;
        }
        public IActionResult List()
        {
            var listslider = oslider.GetAll();
            return View(listslider);
        }
    }
}
