using Microsoft.AspNetCore.Mvc;
using Mvc10_CookieAuthentication.Data;
using Mvc10_CookieAuthentication.Interfaces;
using Mvc10_CookieAuthentication.Models;
using Mvc10_CookieAuthentication.ViewModels;
using Mvc7_CookieAuthentication.Data;

namespace Mvc10_CookieAuthentication.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountContext _ctx;
        private readonly IHashService _hashService;
        
        public AccountController(AccountContext ctx,IHashService hashService)
        {
            _ctx = ctx;
            _hashService = hashService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login([FromQuery] string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl; // 將 ReturnUrl 存到 ViewData 供 View 使用

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginHardCode(LoginViewModel loginVM, [FromQuery] string ReturnUrl)
        {
            if (ModelState.IsValid)// 驗證不得為空白
            {
                if (loginVM.UserName != "Kevin" || loginVM.Password != "12345")
                {
                    ModelState.AddModelError(string.Empty, "帳號密碼有錯~~~");
                    return View(loginVM);
                }
                //通過已上帳密比對成立後，以下開始建立授權。

                // 1.建立Claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,loginVM.UserName),
                    new Claim(ClaimTypes.Email,"kevin@gmail.com"),
                    new Claim(ClaimTypes.Role,"Administrator"),
                };
                // 2.ClaimsIndentity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                // 3.ClaimsPrincipal
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

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
        public async Task<IActionResult> Login(LoginViewModel loginVM, [FromQuery] string ReturnUrl)
        {
            if (ModelState.IsValid)// 驗證不得為空白
            {
                ApplicationUser user = await AuthenticaUser(loginVM);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "帳號密碼有錯~~~");
                    return View(loginVM);
                }
                //通過已上帳密比對成立後，以下開始建立授權。

                // 1.建立Claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Email,user.Email),
                    //new Claim(ClaimTypes.Role,user.Roles[0]),
                    //new Claim(ClaimTypes.Role,user.Roles[1]),
                };

                if (user.Roles.Length > 0)
                {
                    for(int i = 0; i < user.Roles.Length; i++)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, user.Roles[i]));
                    }
                }

                // 2.ClaimsIndentity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                // 3.ClaimsPrincipal
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

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

        //以資料庫查詢驗證使用帳密
        private async Task<ApplicationUser> AuthenticaUser(LoginViewModel loginVM)
        {
            //以帳密去比對User資料表是否有對應的user資料
            User user = await _ctx.Users
                .FirstOrDefaultAsync(u => u.Name.ToUpper() == loginVM.UserName.ToUpper() &&
                u.Password == _hashService.MD5Hash(loginVM.Password));
            //User user = await _ctx.Users
            //    .FirstOrDefaultAsync(u => u.Name.ToUpper() == loginVM.UserName.ToUpper() &&
            //    u.Password == loginVM.Password);
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

                ApplicationUser userInfo = new ApplicationUser
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
                User user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name=registerVM.UserName,
                    Password=_hashService.MD5Hash(registerVM.Password),
                    Email=registerVM.UserName
                };
                _ctx.Users.Add(user);
                _ctx.SaveChanges();

                ViewData["Message"] = "註冊成功 ";

                return View("~/Views/Shared/ResultMessage.cshtml");
            }
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        //登出
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }

        
    }
}
