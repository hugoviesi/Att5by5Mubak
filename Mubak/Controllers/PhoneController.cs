using System.Linq;
using System.Web.Mvc;
using Model;
using Context;

namespace Mubak.Controllers
{
    public class PhoneController : Controller
    {
        private PhoneContext _ctxPhone = new PhoneContext();

        // GET: Sale
        public ActionResult Index()
        {
            return View(_ctxPhone.Phones.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _ctxPhone.Phones.Add(phone);
                _ctxPhone.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone);
        }

        public ActionResult Edit(int id)
        {
            return View(_ctxPhone.Phones.First(p => p.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Phone phone)
        {
            if (ModelState.IsValid)
            {
                Phone phoneUpdate = _ctxPhone.Phones.First(p => p.Id == phone.Id);
                phoneUpdate.Type = phone.Type;
                phoneUpdate.DDD = phone.DDD;
                phoneUpdate.Number = phone.Number;

                _ctxPhone.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone);
        }
        public ActionResult Details(int id)
        {
            return View(_ctxPhone.Phones.First(p => p.Id == id));
        }

        public ActionResult Delete(int id)
        {
            return View(_ctxPhone.Phones.First(p => p.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var phone = _ctxPhone.Phones.First(p => p.Id == id);
            _ctxPhone.Phones.Remove(phone);
            _ctxPhone.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}