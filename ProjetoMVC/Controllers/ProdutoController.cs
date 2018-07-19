using ProjetoMVC.ProdutoServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoMVC.Controllers
{
    public class ProdutoController : Controller
    {
        readonly ProdutoServiceClient _wcf = new ProdutoServiceClient();

        // GET: Produto
        public ActionResult Index()
        {
            List<Produto> produtos = _wcf.FindAll().ToList();
            return View(produtos);
        }

        public ActionResult Details(int id)
        {
            Produto produto = _wcf.Find(id);
            return View(produto);
        }

        public ActionResult Create()
        {
            Produto produto = new Produto();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _wcf.New(produto);
                return RedirectToAction("Index");
            }

            return View(produto);           
        }

        //GET: Produtos/Edit/
        public ActionResult Edit(int id)
        {
            Produto produto = _wcf.Find(id);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _wcf.Update(produto);
                return RedirectToAction("index");
            }

            return View(produto);
        }

        //GET: Produtos/Delete
        public ActionResult Delete(int id)
        {
            Produto produto = _wcf.Find(id);
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _wcf.Delete(id);
            return RedirectToAction("index");
        }
    }
}