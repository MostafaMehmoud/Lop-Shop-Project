using Lap_Shop_Project.BL;
using Lap_Shop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lap_Shop_Project.Controllers
{
    //public class VwCategoryItem
    //{
    //    public string ItemName { get; set; }
    //    public string CategoryName { get; set; }
    //}
    public class HomeController : Controller
    {

        IItems oClsitems;
        ISlider oClsslider;
        public HomeController(IItems items,ISlider slider) 
        {
            oClsitems = items;
            oClsslider = slider;
        }
        
       
           

        public IActionResult Index()
        {
            VmHomePage vm=new VmHomePage();
            vm.listAllItems =oClsitems.GetAllItems(null).Skip(20).Take(20).ToList();
            vm.listRecommendedItems = oClsitems.GetAllItems(null).Skip(60).Take(10).ToList();
            vm.listNewItems = oClsitems.GetAllItems(null).Skip(90).Take(10).ToList();
            vm.ListFreeDelivary = oClsitems.GetAllItems(null).Skip(200).Take(20).ToList();
            vm.Listslider=oClsslider.GetAll().ToList();
            return View(vm);
        }

        public IActionResult Privacy()
        {
            //var items=(from i in context.TbItems join
            //           c in context.TbCategories
            //           on i.ItemId equals c.CategoryId
            //           where i.PurchasePrice > 300
            //           select new VwCategoryItem()
            //           {
            //               CategoryName = c.CategoryName,
            //               ItemName=i.ItemName
            //           }).OrderBy(e=>e.ItemName).ToList();
            //var cate = context.TbItems.FromSqlRaw("select * from TbItems").ToList();
            return View();
        }

       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
