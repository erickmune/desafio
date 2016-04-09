using DesafioMinhaVida.DAO;
using DesafioMinhaVida.Entities;
using DesafioMinhaVida.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioMinhaVida.Controllers
{
    public class ElectricGuitarController : Controller
    {
        public ElectricGuitarDAO DAO { get; private set; }

        public ElectricGuitarController(ElectricGuitarDAO dao)
        {
            this.DAO = dao;
        }

        public ActionResult Index()
        {
            IList<ElectricGuitar> eguitars = DAO.List();
            return View(eguitars);
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(ElectricGuitar guitar)
        {
            if (ModelState.IsValid)
            {
                guitar.DateCreated = DateTime.Now;
                bool resultAdd = this.DAO.Add(guitar);
                guitar.SKU = SKUGenerator.GenerateSKU(guitar);
                bool resultUpdate = this.DAO.Update(guitar);

                if (resultAdd && resultUpdate)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("ErrorPage");
            }
            else
            {
                return View("Form", guitar);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ElectricGuitar guitar = this.DAO.SearchById(id);
            return View(guitar);
        }

        [HttpPost]
        public ActionResult Edit(ElectricGuitar guitar)
        {
            if (ModelState.IsValid)
            {                
                bool result = this.DAO.Update(guitar);
                if (result)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("ErrorPage");
            }
            else
                return View("Edit", guitar);
        }
        
        public ActionResult Delete(int id)
        {
            bool result = this.DAO.Delete(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("ErrorPage");
                
        }

        [HttpGet]
        public JsonResult GetAllGuitarsByJson()
        {
            IList<ElectricGuitar> list = this.DAO.List();
            return Json(list);
        }

        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}