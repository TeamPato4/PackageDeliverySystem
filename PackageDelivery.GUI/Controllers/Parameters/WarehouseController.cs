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
    public class WarehouseController : Controller
    {
        private IWarehouseApplication _app = new WarehouseImpApplication();

        // GET: Warehouse
        public ActionResult Index(string filter = "")
        {
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel warehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warehouseModel);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] WarehouseModel warehouseModel)
        {
            if (ModelState.IsValid)
            {
                WarehouseGUIMapper mapper = new WarehouseGUIMapper();
                WarehouseDTO response = _app.createRecord(mapper.ModelToDTOMapper(warehouseModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(warehouseModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(warehouseModel);
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel warehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warehouseModel);
        }

        // POST: Warehouse/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] WarehouseModel warehouseModel)
        {
            if (ModelState.IsValid)
            {
                WarehouseGUIMapper mapper = new WarehouseGUIMapper();
                WarehouseDTO response = _app.updateRecord(mapper.ModelToDTOMapper(warehouseModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(warehouseModel);
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel warehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warehouseModel);
        }

        // POST: Warehouse/Delete/5
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
