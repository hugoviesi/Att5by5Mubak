using System.Linq;
using System.Web.Mvc;
using Model;
using Context;

namespace Mubak.Controllers
{
    public class SaleController : Controller
    {
        private SaleContext _ctxSale = new SaleContext();

        // GET: Sale
        public ActionResult Index()
        {
            var lst = _ctxSale.Sales.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            ViewBag.PaymentList = new SelectList(_ctxSale.Payments, "Id", "Installments", "Id");
            //ViewBag.ItemProductList = new SelectList(_ctxSale.ItemProducts, "Id", "Description", "Id");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Payment, DateSale, Costumer, Items, TotalValue")] Sale sales)
        {
            if (ModelState.IsValid)
            {
                sales.Payment = _ctxSale.Payments.First(ip => ip.Id == sales.Payment.Id);
                _ctxSale.Sales.Add(sales);
                _ctxSale.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sales);
        }

        public ActionResult Edit(int id)
        {
            var sales = _ctxSale.Sales.First(d => d.Id == id);
            ViewBag.PaymentList = new SelectList(_ctxSale.Payments, "Id", "Installments", sales.Id);
            return View(sales);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Payment, DateSale, Costumer, Items, TotalValue")] Sale sales)
        {
            if (ModelState.IsValid)
            {
                Sale saleUpdate = _ctxSale.Sales.First(ip => ip.Id == sales.Id);
                saleUpdate.Payment = _ctxSale.Payments.First(p => p.Id == sales.Payment.Id);
                saleUpdate.DateSale = sales.DateSale;
                saleUpdate.Costumer = sales.Costumer;
                saleUpdate.Items = sales.Items;
                saleUpdate.TotalValue = sales.TotalValue;
                _ctxSale.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sales);
        }

        public ActionResult Details(int id)
        {
            return View(_ctxSale.Sales.First(s => s.Id == id));
        }

        public ActionResult Delete(int id)
        {
            return View(_ctxSale.Sales.First(s => s.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var sale = _ctxSale.Sales.First(s => s.Id == id);
            _ctxSale.Sales.Remove(sale);
            _ctxSale.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}