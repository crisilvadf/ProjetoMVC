using ProjetoMVC.ClienteServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoMVC.Controllers
{
    public class ClienteController : Controller
    {
        readonly ClienteServiceClient _wcf = new ClienteServiceClient();

        // GET: Cliente
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            List<Cliente> cliente = _wcf.FindAll().ToList();
            return View(cliente);
        }

        public ActionResult Details(int id)
        {
            Cliente cliente = _wcf.Find(id);
            return View(cliente);
        }

        public ActionResult Create()
        {
            Cliente cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _wcf.New(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        //GET: Cliente/Edit/
        public ActionResult Edit(int id)
        {
            Cliente cliente = _wcf.Find(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _wcf.Update(cliente);
                return RedirectToAction("index");
            }

            return View(cliente);
        }

        //GET: Cliente/Delete
        public ActionResult Delete(int id)
        {
            Cliente cliente = _wcf.Find(id);
            return View(cliente);
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