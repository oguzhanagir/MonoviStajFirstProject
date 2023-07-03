using Microsoft.AspNetCore.Mvc;
using MonoviStajFirstProject.Business.Abstract;
using MonoviStajFirstProject.Entities.Concrete;

namespace MonoviStajFirstProject.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserList()
        {
            var userList = _userService.GetAll();
            return View(userList);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (user !=null)
            {
                _userService.Create(user);
                ViewBag.Message = "Kullanıcı Eklendi";
                return RedirectToAction("UserList", "User");
            }
            ViewBag.Message = "Kullanıcı Eklenemedi";
            return View("AddUser", "User");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            if (user != null)
            {
                _userService.Update(user);
                ViewBag.Message = "Kullanıcı Güncellendi";
                return RedirectToAction("UserList", "User");
            }
            ViewBag.Message = "Kullanıcı Güncellendi";
            return View("UpdateUser", "User");
        }


      
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("UserList", "User");
        }


    }
}
