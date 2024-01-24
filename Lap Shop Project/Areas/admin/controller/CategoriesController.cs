using Lap_Shop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LapShop.Utlities;
using Lap_Shop_Project.Methods_Helper;
using Lap_Shop_Project.BL;
using Microsoft.AspNetCore.Authorization;

namespace Lap_Shop_Project.Areas.admin.controller
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        public CategoriesController(ICategory category) 
        {
            OclsCategories=category;
        }
        ICategory OclsCategories;
        public IActionResult List()
        {
           
            return View(OclsCategories.GetAll());
        }
        public IActionResult Edit(int? id)
        {
            var category = new TbCategory();
            if (id != null)
            {
               
                category = OclsCategories.GetById(Convert.ToInt32(id));
            }
            if (category.ShowInHomePage == null)
            {
                category.ShowInHomePage = false;
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCategory category,List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", category);

            }

            category.ImageName = await helper.UploadImage(files,"Categories");
            OclsCategories.Save(category);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int CategoryId)
        {
            OclsCategories.Delete(CategoryId);
            return RedirectToAction("List");
        }
       
    }
}
