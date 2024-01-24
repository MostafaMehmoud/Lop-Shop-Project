using Lap_Shop_Project.BL;
using Lap_Shop_Project.Methods_Helper;
using Lap_Shop_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lap_Shop_Project.Areas.admin.controller
{
    [Authorize(Roles ="Admin,DataEntry")]
    [Area("Admin")]
    public class ItemsController : Controller
    {
        public ItemsController(IItems items,ICategory category,IOs os,IItemType itemType) 
        {
            oClsItems= items;
            oclsCategories= category;
            oClsOs= os;
            oClsItemType= itemType;
        }

        ICategory oclsCategories;
        IItems oClsItems ;
        IItemType oClsItemType;
        IOs oClsOs;
        [AllowAnonymous]
        public IActionResult List()
        {
            ViewBag.lisCategories= oclsCategories.GetAll();
            var items=oClsItems.GetAllItems(null);
            return View(items);
        }
        public IActionResult Search(int id)
        {
            ViewBag.lisCategories = oclsCategories.GetAll();
            var items = oClsItems.GetAllItems(id);
            return View("List",items);
        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    ViewBag.lisCategories = oclsCategories.GetAll();
        //    ViewBag.lisOs = oClsOs.GetAll();
        //    ViewBag.lisItemType = oClsItemType.GetAll();
        //    var item=oClsItems.GetById(id);
        //    return View(item);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbItem item, List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", item);

            }

            item.ImageName = await helper.UploadImage(files, "Items");
            oClsItems.Save(item);
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? itemid)
        {
            var item = new TbItem();
            ViewBag.lisCategories = oclsCategories.GetAll();
            ViewBag.lisOs = oClsOs.GetAll();
            ViewBag.lisItemType = oClsItemType.GetAll();
            if (itemid != null)
            {

                item = oClsItems.GetById(Convert.ToInt32(itemid));
            }
           
            return View(item);
        }
        public IActionResult Delete(int itemid)
        {
            oClsItems.Delete(itemid);
            return RedirectToAction("List");
        }


    }
}
