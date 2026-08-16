using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;    // Claims會用到

namespace Mvc7_CookieAuthentication.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountContext _ctx;
        private readonly IHashService _hashService;
        public AccountController(AccountContext ctx, IHashService hashService)
        {
            _ctx = ctx;
            _hashService = hashService; 
        }

        //登入
        [HttpGet]
        public IActionResult Login([FromQuery] string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl; // 將 ReturnUrl 存到 ViewData 供 View 使用

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM, [FromQuery] string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //以下這段要改成和資料庫驗證做比對
                if (loginVM.UserName != "Kevin" || loginVM.Password != "12345")
                {
                    ModelState.AddModelError(string.Empty, "帳號密碼有錯!!!");

                    return View(loginVM);
                }


                //通過以上帳密比對成立後, 以下開始建立授權
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginVM.UserName),
                    new Claim(ClaimTypes.Email,"kevin@gmail.com"),
                    new Claim(ClaimTypes.Role,"Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                    );

                if (ReturnUrl != null)
                {
                    // LocalRedirectToPage 會檢查 URL 的安全性，推薦使用。
                    // 如果 returnUrl 是有效且安全的本地路徑，則跳轉。
                    return LocalRedirect(ReturnUrl);
                }
                else
                {
                    // 如果沒有 returnUrl (或 returnUrl 無效/不安全)，則跳轉到預設頁面
                    return LocalRedirect("~/Reports/SalesReport");
                }

            }

            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginDB(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await AuthenticateUser(loginVM); //驗證使用者帳密

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "帳號密碼有錯!!!");

                    return View(loginVM);
                }

                //通過以上帳密比對成立後, 以下開始建立授權
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginVM.UserName),
                    new Claim(ClaimTypes.Role, user.Roles[0]),
                    new Claim(ClaimTypes.Role, user.Roles[1]),
                    //new Claim(ClaimTypes.Role, "Administrator") // 如果要有「群組、角色、權限」，可以加入這一段
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                    );

                return LocalRedirect("~/Reports/SalesReport");

            }

            return View(loginVM);
        }

        //進行使用者帳號及密碼驗證
        private async Task<ApplicationUser> AuthenticateUser(LoginViewModel loginVM)
        {
            //以帳號及密碼去比對Users資料表是否有對映的User資料
            var user = await _ctx.Users
                .FirstOrDefaultAsync(u => u.Name.ToUpper() == loginVM.UserName.ToUpper() && u.Password == loginVM.Password);


            //var user = await _ctx.Users
            //    .FirstOrDefaultAsync(u => u.Name.ToUpper() == loginVM.UserName && u.Password == _hashService.MD5Hash(loginVM.Password));


            //以下這段要改成和EF資料庫比對帳號及密碼
            if (user != null)
            {

                //讀取第一個Role
                var roleName = await _ctx.Users
                                .Where(u => u.Name == loginVM.UserName)
                                .SelectMany(u => u.UserRoles)
                                .Select(ur => ur.Role.Name)
                                .FirstOrDefaultAsync();

                //讀取所有Role角色
                List<string> roleNames = await _ctx.Users
                        .Where(u => u.Name == loginVM.UserName)
                        .SelectMany(u => u.UserRoles)
                        .Select(ur => ur.Role.Name)
                        .ToListAsync();


                var userInfo = new ApplicationUser
                {
                    Name = user.Name,
                    Email = user.Email,
                    Nickname = user.Nickname,
                    PhoneNo = user.PhoneNo,
                    Role = roleName,
                    Roles = roleNames.ToArray()
                };

                return userInfo;
            }
            else
            {
                return null;
            }
        }

        //登出
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }

        //註冊帳號
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                //ViewModel => Data Model
                User user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = registerVM.UserName,
                    Password = _hashService.MD5Hash(registerVM.Password),
                };

                _ctx.Users.Add(user);
                _ctx.SaveChanges();

                ViewData["Message"] = "帳號註冊成功!";  //顯示訊息

                return View("~/Views/Shared/ResultMessage.cshtml");
            }

            return View(registerVM);
        }


        public IActionResult Forbidden()
        {
            return View();
        }

    }
}
