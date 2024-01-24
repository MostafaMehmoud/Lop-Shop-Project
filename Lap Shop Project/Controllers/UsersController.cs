using Bl;
using Lap_Shop_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lap_Shop_Project.Controllers
{
    public class UsersController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            UserModel model = new UserModel()
            {
                ReturnUrl = returnUrl,
            };  
            return View(model);
        }
        public IActionResult Register()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Register", model);
            }
            ApplicationUser user=new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName=model.Email
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var loginResult=await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    if(loginResult.Succeeded)
                    {
                        return Redirect("/Order/successed");
                    }
                }
                else
                {

                }
            }catch (Exception ex)
            {

            }
            return View(new UserModel());
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Register", model);
            }
            ApplicationUser user = new ApplicationUser()
            {
               
                Email = model.Email,
                UserName = model.Email
            };
            try
            {
               
               var loginResult = await _signInManager.PasswordSignInAsync(user.Email, model.Password, true, true);
                var myuser =await _userManager.FindByEmailAsync(user.Email);
               await _userManager.AddToRoleAsync(myuser, "Customer");
               if (loginResult.Succeeded)
                    {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return Redirect("~/");
                    else
                        return Redirect(model.ReturnUrl);

                    }
               
                    return Redirect("/Order/Successed");
            }
            catch (Exception ex)
            {

            }
            return View(new UserModel());

        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
