using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MVC_Kutuphane_Yonetim.Entities;
using MVC_Kutuphane_Yonetim.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MVC_Kutuphane_Yonetim.Controllers
{
    public class AuthController : Controller
    {

        private static List<UserEntity> _users = new List<UserEntity>()
        {
            new UserEntity{ Id = 1, FullName ="asd", Email=".", Password=".", PhoneNumber="." }
        };

        private readonly IDataProtector _dataProtector;
        public AuthController(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> SignUp(SignUpViewModel formData)
        {
            if(!ModelState.IsValid)
            {
                return View(formData);
            }

            var user = _users.FirstOrDefault(x  => x.Email.ToLower() == formData.Email.ToLower());
            if (user is not null)
            {       
                ViewBag.Error = "Bu email adresiyle zaten bir kullanıcı mevcut.";
                return View(formData); 
            }

            var newUser = new UserEntity()
            {
                Id = _users.Max(x => x.Id) + 1,
                Email = formData.Email.ToLower(),
                Password = _dataProtector.Protect(formData.Password)

            };

            _users.Add(newUser);

            // Kullanıcıyı kaydettikten sonra otomatik olarak oturum açalım
            var claims = new List<Claim>
    {
             new Claim("email", newUser.Email),
             new Claim("id", newUser.Id.ToString())
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(5)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            // Oturum açıldıktan sonra anasayfaya yönlendir
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignIn(SignInViewModel formData)
        {
            var user = _users.FirstOrDefault(x => x.Email == formData.Email.ToLower());

            if (user is null)
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
                return View(formData);
            }

            var rawPassword = _dataProtector.Unprotect(user .Password);
            if(rawPassword ==formData.Password)
            {

                var claims = new List<Claim>();

                claims.Add(new Claim("email", user.Email));
                claims.Add(new Claim("id", user.Id.ToString()));

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //claims içerisindeki verilerle oturum açılacağı için identity nesnesi tanımlandı

                var autProperties = new AuthenticationProperties
                {
                    AllowRefresh = true, //yenilenebilir oturum
                    ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(5))
                    //oturum açıldıktan sonra 5 saat geçerli

                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);


            }

            else
            {

                ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
                    return View(formData);
            }

            return RedirectToAction("List", "Book");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
