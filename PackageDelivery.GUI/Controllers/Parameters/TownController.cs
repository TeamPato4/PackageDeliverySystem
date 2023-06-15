using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Application.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class TownController : Controller
    {
        private ITownApplication _app = new TownImpApplication();

        // GET: Town
        public ActionResult Index(string filter = "")
        {
            TownGUIMapper mapper = new TownGUIMapper();
            IEnumerable<TownModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: Town/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownGUIMapper mapper = new TownGUIMapper();
            TownModel TownModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (TownModel == null)
            {
                return HttpNotFound();
            }
            return View(TownModel);
        }

        // GET: Town/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Town/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TownModel TownModel)
        {
            if (ModelState.IsValid)
            {
                TownGUIMapper mapper = new TownGUIMapper();
                TownDTO response = _app.createRecord(mapper.ModelToDTOMapper(TownModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(TownModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(TownModel);
        }

        // GET: Town/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownGUIMapper mapper = new TownGUIMapper();
            TownModel TownModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (TownModel == null)
            {
                return HttpNotFound();
            }
            return View(TownModel);
        }

        // POST: Town/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TownModel TownModel)
        {
            if (ModelState.IsValid)
            {
                TownGUIMapper mapper = new TownGUIMapper();
                TownDTO response = _app.updateRecord(mapper.ModelToDTOMapper(TownModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(TownModel);
        }

        // GET: Town/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownGUIMapper mapper = new TownGUIMapper();
            TownModel TownModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (TownModel == null)
            {
                return HttpNotFound();
            }
            return View(TownModel);
        }

        // POST: Town/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            bool response = _app.deleteRecordById(id);
            if (response)
            {
                ViewBag.ClassName = ActionMessages.successClass;
                ViewBag.Message = ActionMessages.successMessage;
                return RedirectToAction("Index");
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View();
        }

    }
}