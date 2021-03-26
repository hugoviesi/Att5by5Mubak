using System.Linq;
using System.Web.Mvc;
using Model;
using Context;

namespace Mubak.Controllers
{
    public class AddressController : Controller
    {
        private AddressContext _ctxAddress = new AddressContext();

        // GET: Sale
        public ActionResult Index()
        {
            return View(_ctxAddress.Addresses.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _ctxAddress.Addresses.Add(address);
                _ctxAddress.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        public ActionResult Edit(int id)
        {
            return View(_ctxAddress.Addresses.First(a => a.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                Address addressUpdate = _ctxAddress.Addresses.First(a => a.Id == address.Id);
                addressUpdate.Street = address.Street;
                addressUpdate.Neighborhood = address.Neighborhood;
                addressUpdate.ZipCode = address.ZipCode;
                addressUpdate.Locale = address.Locale;
                addressUpdate.Region = address.Region;

                _ctxAddress.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }
        public ActionResult Details(int id)
        {
            return View(_ctxAddress.Addresses.First(a => a.Id == id));
        }

        public ActionResult Delete(int id)
        {
            return View(_ctxAddress.Addresses.First(a => a.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var address = _ctxAddress.Addresses.First(a => a.Id == id);
            _ctxAddress.Addresses.Remove(address);
            _ctxAddress.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}