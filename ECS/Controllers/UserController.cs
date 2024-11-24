using ECS.Extensions;
using ECS.Models;
using ECS.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ECS.Controllers
{
    public class UserController : Controller
    {
        private readonly EcsContext _context;

        public UserController(EcsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Trả về trang đăng ký nếu dữ liệu không hợp lệ
            }

            try
            { 
                // Kiểm tra nếu user đã tồn tại
                var existingUser = _context.Users
                    .FirstOrDefault(u => u.Username == model.Username || u.Email == model.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Username or email already exists.");
                    return View(model); // Truyền lại RegisterVM
                }

                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    CreatedAt = DateTime.Now,
                    Roles = "User",
                    EmailVerified = true,

                    States = "Active", //false + gửi mail active tài khoản
                    Salt = GetRandom.Random()
                };
                user.PasswordHash = model.PasswordHash.ToMd5Hash(user.Salt);
                _context.Add(user);
                _context.SaveChanges(); 

                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi (Log error)
                ViewBag.ErrorMessage = ex.Message; // Có thể hiển thị thông báo lỗi
                return View(model);
            }
        }
    }
}
