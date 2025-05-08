using demo.datalayer.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models.account;
using WebApplication5.utilities;

namespace WebApplication5.Controllers
{
    public class accountcontroller : Controller
    {


        
            private readonly UserManager<appuser> _userManager;
            private readonly SignInManager<appuser> _signInManager;

            public accountcontroller(UserManager<appuser> userManager, SignInManager<appuser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            // دلوقتي تقدر تستخدم _userManager و _signInManager داخل أي أكشن
        

        #region register
        public IActionResult register()
        {
            return View();

        }
        [HttpPost]
        public IActionResult register(RegisterViewModel viewmodel)
        {
            if(ModelState.IsValid)//server side validation
            {
                var user = new appuser()
                {
                    UserName = viewmodel.UserName,
                    Email = viewmodel.Email,
                    isagree=viewmodel.IsAgree,
                    firstname=viewmodel.FirstName,
                    lastname=viewmodel.LastName,
                };
              var result= _userManager.CreateAsync(user,viewmodel.Password).Result;
                if(result.Succeeded)
                {
                    return RedirectToAction("login");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);

                    }
                    return View(viewmodel);
                }
            }
            return View(viewmodel);
        }
        #endregion
        #region login
        [HttpGet]
        public IActionResult login() {
        return View();
        }
        [HttpPost]
        public IActionResult login(login_view_model view_Model) { 
        if(!ModelState.IsValid) return View(view_Model);
            var user = _userManager.FindByEmailAsync(view_Model.Email).Result;
if(user != null)
            {
                bool flag=_userManager.CheckPasswordAsync(user,view_Model.Password).Result;
                if(flag)
                {
                    var result = _signInManager.PasswordSignInAsync(user, view_Model.Password, view_Model.RememberMe, false).Result;
                    if (result.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "ypur account not allowed");
                    if (result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "your account is locked");
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(HomeController.Index),"home");
                    }
                }
               
            }

            else
            {
                ModelState.AddModelError(string.Empty, "invalid login");
             
                
            }
return View(view_Model);
        }
        #endregion
        #region sign out
        public async Task< IActionResult> signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(login));

        }

        #endregion
        #region forget pass
        [HttpGet]
        public IActionResult forgetpassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult sendresetpassword(ForgetPasswordViewModel viewModel)
        {

            if(ModelState .IsValid) {
                var user = _userManager.FindByEmailAsync(viewModel.email).Result;
                 if (user is not null) {
                    var token=_userManager.GeneratePasswordResetTokenAsync(user).Result;
                    //base url/account/reset pass/abeerreda07@gmail.com/token
                    var ResetPassURL = Url.Action("ResetPassword","account",new {email=viewModel.email,token},Request.Scheme);
                    //create email
                    var email = new email()
                    {
                        to = viewModel.email,
                        subject = "Reset Password",
                        body = ResetPassURL

                    };
                    //send email
                    emailsettings.sendemail(email);
                    return RedirectToAction("CheckYourInbox");

                }
              
            }
            ModelState.AddModelError(string.Empty, "invalid operation");
            return View(nameof(forgetpassword), viewModel);
        }
        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }
        [HttpGet]
        public IActionResult resetpassword(string email,string token)
        {
            TempData["email"]=email
                ; TempData["token"]=token;

            return View();
        }
        [HttpPost]

        public IActionResult resetpassword(ResetPasswordViewModel viewModel)
        { 
        if(ModelState.IsValid)
            {
                return View(viewModel);
            }
            string email = TempData["email"] as string??string.Empty;
            string token= TempData["token"] as string??string.Empty;
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
              var result=  _userManager.ResetPasswordAsync(user, token,viewModel.password).Result;
                if(result.Succeeded) {
                    return RedirectToAction(nameof(login));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return View(nameof(resetpassword), viewModel);
            
        }
            #endregion
        }
}