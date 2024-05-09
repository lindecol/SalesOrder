using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDesicionTable;
using WebDesicionTable.Models;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Web.Security;

namespace WebDesicionTable.Controllers
{ 
    public class AdminController : Controller
    {
     
        private strConexion db;

        [HandleError]
        private bool Conexion()
        {
            try
            {
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                entityBuilder.Provider = "Oracle.DataAccess.Client";
                entityBuilder.ProviderConnectionString = Session["strConexion"].ToString();
                entityBuilder.Metadata = string.Format(@"res://*/ModelSalesOrder.csdl|res://*/ModelSalesOrder.ssdl|res://*/ModelSalesOrder.msl");
                string connString = entityBuilder.ToString();
                EntityConnection EtyConexion = new EntityConnection(connString);
                db = new strConexion(EtyConexion);
                return true;
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Error de conexión");
            }
        }

        //
        // GET: /Admin/
        [Authorize]
        public ViewResult Index()
        {
            Conexion();
            return View(db.SPH_DECISION_TABLE.ToList());
        }

        //
        // GET: /Admin/Details/5
        [Authorize]
        public ViewResult Details(decimal id)
        {
            Conexion();
            SPH_DECISION_TABLE sph_decision_table = db.SPH_DECISION_TABLE.Single(s => s.ID_DESICION_TABLE == id);
            return View(sph_decision_table);
        }

        //
        // GET: /Admin/Create
        [Authorize]
        public ActionResult Create(LogOnModel Login)
        {
           Session["strConexion"] = "DATA SOURCE=" + Login.DB + ";PASSWORD=" + Login.PasswordBd + ";PERSIST SECURITY INFO=True;USER ID=" + Login.IdUsuario;
           Conexion();
           return View();
        } 

        //
        // POST: /Admin/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(SPH_DECISION_TABLE sph_decision_table)
        {
            if (ModelState.IsValid)
            {
                Conexion();

                db.SPH_DECISION_TABLE.AddObject(sph_decision_table);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(sph_decision_table);
        }
        
        //
        // GET: /Admin/Edit/5
        [Authorize]
        public ActionResult Edit(decimal id)
        {
            Conexion();
            SPH_DECISION_TABLE sph_decision_table = db.SPH_DECISION_TABLE.Single(s => s.ID_DESICION_TABLE == id);
            return View(sph_decision_table);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(SPH_DECISION_TABLE sph_decision_table)
        {
            if (ModelState.IsValid)
            {
                Conexion();
                db.SPH_DECISION_TABLE.Attach(sph_decision_table);
                db.ObjectStateManager.ChangeObjectState(sph_decision_table, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sph_decision_table);
        }

        //
        // GET: /Admin/Delete/5
        [Authorize]
        public ActionResult Delete(decimal id)
        {
            Conexion();
            SPH_DECISION_TABLE sph_decision_table = db.SPH_DECISION_TABLE.Single(s => s.ID_DESICION_TABLE == id);
            return View(sph_decision_table);
        }

        //
        // POST: /Admin/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Conexion();
            SPH_DECISION_TABLE sph_decision_table = db.SPH_DECISION_TABLE.Single(s => s.ID_DESICION_TABLE == id);
            db.SPH_DECISION_TABLE.DeleteObject(sph_decision_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
                base.Dispose(disposing);
            }
        }
    }
}