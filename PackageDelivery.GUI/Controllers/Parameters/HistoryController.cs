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
    public class HistoryController : Controller
    {
        private IHistoryApplication _app = new HistoryImpApplication();
        private IWarehouseApplication _wApp = new WarehouseImpApplication();

        // GET: History
        public ActionResult Index(string filter = "")
        {
            HistoryGUIMapper mapper = new HistoryGUIMapper();
            IEnumerable<HistoryModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryGUIMapper mapper = new HistoryGUIMapper();
            HistoryModel historyModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // GET: History/Create
        public ActionResult Create()
        {
            IEnumerable<WarehouseDTO> wlist = this._wApp.getRecordsList(string.Empty);
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            HistoryModel model = new HistoryModel()
            {
                WarehouseList = mapper.DTOToModelMapper(wlist),
            };
            return View(model);
        }

        // POST: History/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdmissionDate,DepartureDate,Description,IdPackage,IdWarehouse")] HistoryModel historyModel)
        {
            if (ModelState.IsValid)
            {
                HistoryGUIMapper mapper = new HistoryGUIMapper();
                HistoryDTO response = _app.createRecord(mapper.ModelToDTOMapper(historyModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(historyModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(historyModel);
        }

        // GET: History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryGUIMapper mapper = new HistoryGUIMapper();
            HistoryModel historyModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<WarehouseDTO> wlist = this._wApp.getRecordsList(string.Empty);
            WarehouseGUIMapper wmapper = new WarehouseGUIMapper();

            historyModel.WarehouseList = wmapper.DTOToModelMapper(wlist);

            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // POST: History/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdmissionDate,DepartureDate,Description,IdPackage,IdWarehouse")] HistoryModel historyModel)
        {
            if (ModelState.IsValid)
            {
                HistoryGUIMapper mapper = new HistoryGUIMapper();
                HistoryDTO response = _app.updateRecord(mapper.ModelToDTOMapper(historyModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(historyModel);
        }

        // GET: History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryGUIMapper mapper = new HistoryGUIMapper();
            HistoryModel historyModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // POST: History/Delete/5
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


