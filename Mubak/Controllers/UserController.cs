using System.Linq;
using System.Web.Mvc;
using Model;
using Context;
using Services;
using System.Web.Security;

namespace Mubak.Controllers
{
    public class UserController : Controller
    {
        private UserContext _ctxUser = new UserContext();
        private UserLogin _serviceUser = new UserLogin();

        [Authorize(Roles= "Admin")]
        public ActionResult Index()
        {
            return View(_ctxUser.Users.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if(user.Login == "admin")
                {
                    user.Permission = "Admin";
                }
                else
                {
                    user.Permission = "Usuario";
                }
                _ctxUser.Users.Add(user);
                _ctxUser.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(_ctxUser.Users.First(u => u.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                User userUpdate = _ctxUser.Users.First(u => u.Id == user.Id);
                userUpdate.Situation = user.Situation;
                userUpdate.Login = user.Login;
                userUpdate.Password = user.Password;
                userUpdate.CPF = user.CPF;
                userUpdate.Name = user.Name;
                userUpdate.Address = user.Address;
                userUpdate.Phone = user.Phone;
                userUpdate.Permission = user.Permission;
                userUpdate.Email = user.Email;

                _ctxUser.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [Authorize]
        public ActionResult Details(string login)
        {
            return View(_ctxUser.Users.First(u => u.Login == login));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(_ctxUser.Users.First(u => u.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirm(int id)
        {
            var user = _ctxUser.Users.First(u => u.Id == id);
            _ctxUser.Users.Remove(user);
            _ctxUser.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var checkedUser = _serviceUser.CheckUser(user);

            if (checkedUser != null)
            {
                FormsAuthentication.SetAuthCookie(checkedUser.Login, false);
                return RedirectToAction("Showcase", "Product");
            }
            ModelState.AddModelError("", "Invalid User/Password");
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Product");
        }
    }
}