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
    public class PedidoesController : Controller
    {
        private crepasdbEntities db = new crepasdbEntities();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedidoes = db.Pedidoes.Include(p => p.TipoPago).Include(p => p.TipoPedido).Include(p => p.Usuario);
            return View(pedidoes.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoPago = new SelectList(db.TipoPagoes, "Id", "campo");
            ViewBag.IdTipo = new SelectList(db.TipoPedidoes, "Id", "NombreStatus");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Username");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUsuario,IdTipo,Direccion,Descripcion,IdTipoPago,monto")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPago = new SelectList(db.TipoPagoes, "Id", "campo", pedido.IdTipoPago);
            ViewBag.IdTipo = new SelectList(db.TipoPedidoes, "Id", "NombreStatus", pedido.IdTipo);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Username", pedido.IdUsuario);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPago = new SelectList(db.TipoPagoes, "Id", "campo", pedido.IdTipoPago);
            ViewBag.IdTipo = new SelectList(db.TipoPedidoes, "Id", "NombreStatus", pedido.IdTipo);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Username", pedido.IdUsuario);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUsuario,IdTipo,Direccion,Descripcion,IdTipoPago,monto")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPago = new SelectList(db.TipoPagoes, "Id", "campo", pedido.IdTipoPago);
            ViewBag.IdTipo = new SelectList(db.TipoPedidoes, "Id", "NombreStatus", pedido.IdTipo);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Username", pedido.IdUsuario);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
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
