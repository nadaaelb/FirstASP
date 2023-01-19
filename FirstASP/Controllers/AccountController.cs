using FirstASP.MyIdentity;
using FirstASP.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstASP.Controllers
{
    public class AccountController : Controller
    {
        //inject SignInManager
        private SignInManager<SiteUser> _signInManager;
        private UserManager<SiteUser> _userManager;
        public AccountController(SignInManager<SiteUser> signInManager, UserManager<SiteUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        //login
        //logout
        //register






        //step 1: Log in form
        public IActionResult Login()
        {
            //optional - if the user is already authenticated
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated == true)
                return RedirectToAction("Index", "Games");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userEnteredData)
        {
            if (ModelState.IsValid)
            {
                //attempt to login the user
                var result = await _signInManager.PasswordSignInAsync(userEnteredData.UserName,
                    userEnteredData.Password, userEnteredData.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Games");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to login");


                }

            }


            return View(userEnteredData);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Games");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userEnteredData)
        {
            if(ModelState.IsValid)
            {
                SiteUser newUser = new SiteUser();
                newUser.UserName = userEnteredData.UserName;
                newUser.FirstName = userEnteredData.FirstName;
                newUser.LastName = userEnteredData.LastName;
                newUser.Email = userEnteredData.Email;
                newUser.PhoneNumber = userEnteredData.Phone;

                //attempt to register the new account
                var result = await _userManager.CreateAsync(newUser, userEnteredData.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Games");
                else
                {
                    foreach(var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                    
            }
          //return to view
                return View(userEnteredData);
            }
        
    }
}
