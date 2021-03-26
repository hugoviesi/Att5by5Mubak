using Context;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mubak.Controllers
{
    public class ItemProductController : Controller
    {
        private ItemProductContext _ctxItemProduct = new ItemProductContext();

        // GET: ItemProduct
        public ActionResult Index()
        {
            var lst = _ctxItemProduct.ItemsProducts.ToList();
            return View(lst);
        }

        public ActionResult Create()
        {
            ViewBag.ProductList = new SelectList(_ctxItemProduct.Products, "Id", "Description", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Product, UnitaryValue, Amount, TotalValue")] ItemProduct itemProduct)
        {
            if (ModelState.IsValid)
            {
                itemProduct.Product = _ctxItemProduct.Products.First(ip => ip.Id == itemProduct.Product.Id);
                _ctxItemProduct.ItemsProducts.Add(itemProduct);
                _ctxItemProduct.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemProduct);
        }

        public ActionResult Edit(int id)
        {
            var itemProduct = _ctxItemProduct.ItemsProducts.First(d => d.Id == id);
            ViewBag.ProductList = new SelectList(_ctxItemProduct.Products, "Description", "Model", "Brand", itemProduct.Id);
            return View(itemProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Product, UnitaryValue, Amount, TotalValue")] ItemProduct itemProduct)
        {
            if (ModelState.IsValid)
            {
                ItemProduct itemProductUpdate = _ctxItemProduct.ItemsProducts.First(ip => ip.Id == itemProduct.Id);
                itemProductUpdate.Product = _ctxItemProduct.Products.First(p => p.Id == itemProduct.Product.Id);
                itemProductUpdate.UnitaryValue = itemProduct.UnitaryValue;
                itemProductUpdate.Amount = itemProduct.Amount;
                itemProductUpdate.TotalValue = itemProduct.TotalValue;
                _ctxItemProduct.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemProduct);
        }

        public ActionResult Detail(int id)
        {
            return View(_ctxItemProduct.ItemsProducts.First(ip => ip.Id == id));
        }

        public ActionResult Delete(int id)
        {
            var itemProduct = _ctxItemProduct.ItemsProducts.First(ip => ip.Id == id);
            return View(itemProduct);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var itemProduct = _ctxItemProduct.ItemsProducts.First(ip => ip.Id == id);
            _ctxItemProduct.ItemsProducts.Remove(itemProduct);
            _ctxItemProduct.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}