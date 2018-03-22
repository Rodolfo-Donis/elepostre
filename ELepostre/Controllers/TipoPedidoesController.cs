using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ELepostre.Models.Entity;

namespace ELepostre.Controllers
{
    public class TipoPedidoesController : Controller
    {
        private crepasdbEntities db = new crepasdbEntities();

        // GET: TipoPedidoes
        public ActionResult Index()
        {
            return View(db.TipoPedidoes.ToList());
        }

        // GET: TipoPedidoes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPedido tipoPedido = db.TipoPedidoes.Find(id);
            if (tipoPedido == null)
            {
                return HttpNotFound();
            }
            return View(tipoPedido);
        }

        // GET: TipoPedidoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreStatus,Descripcion")] TipoPedido tipoPedido)
        {
            if (ModelState.IsValid)
            {
                db.TipoPedidoes.Add(tipoPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPedido);
        }

        // GET: TipoPedidoes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPedido tipoPedido = db.TipoPedidoes.Find(id);
            if (tipoPedido == null)
            {
                return HttpNotFound();
            }
            return View(tipoPedido);
        }

        // POST: TipoPedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreStatus,Descripcion")] TipoPedido tipoPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPedido);
        }

        // GET: TipoPedidoes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPedido tipoPedido = db.TipoPedidoes.Find(id);
            if (tipoPedido == null)
            {
                return HttpNotFound();
            }
            return View(tipoPedido);
        }

        // POST: TipoPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TipoPedido tipoPedido = db.TipoPedidoes.Find(id);
            db.TipoPedidoes.Remove(tipoPedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
