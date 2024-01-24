using Lap_Shop_Project.BL;
using Lap_Shop_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lap_Shop_Project.Controllers
{
    public class ItemController : Controller
    {

        IItems oclsItem;
        IItemImages oclsItemImages;
        public ItemController(IItems items,IItemImages itemImages) 
        {
            oclsItem = items;
            oclsItemImages = itemImages;
        }
        public IActionResult Details(int id)
        {
            VmItemDetails vm=new VmItemDetails();
            var item =oclsItem.GetItemById(id);
            vm.vwItem = item;
            vm.vwRecommenendItemlist = oclsItem.GetRecommenendItems(id);
            vm.imageList=oclsItemImages.GetById(id);
            return View(vm);
        }
    }
}
