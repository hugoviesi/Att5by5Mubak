using Context;
using Model;
using System.Linq;
using System.Web.Mvc;

namespace Mubak.Controllers
{
    public class PaymentController : Controller
    {
        private PaymentContext _ctxPayment = new PaymentContext();

        // GET: Payment
        public ActionResult Index()
        {
            return View(_ctxPayment.Payments.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _ctxPayment.Payments.Add(payment);
                _ctxPayment.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        public ActionResult Edit(int id)
        {
            return View(_ctxPayment.Payments.First(p => p.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Payment payment)
        {
            if (ModelState.IsValid)
            {
                Payment paymentUpdate = _ctxPayment.Payments.First(p => p.Id == payment.Id);
                paymentUpdate.Installments = payment.Installments;
                _ctxPayment.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }
        public ActionResult Details(int id)
        {
            return View(_ctxPayment.Payments.First(p => p.Id == id));
        }

        public ActionResult Delete(int id)
        {
            return View(_ctxPayment.Payments.First(p => p.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var payments = _ctxPayment.Payments.First(p => p.Id == id);
            _ctxPayment.Payments.Remove(payments);
            _ctxPayment.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}