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
    public class OfficeController : Controller
    {
        private IOfficeApplication _app = new OfficeImpApplication();
        private ITownApplication _tApp = new TownImpApplication();

        // GET: Office
        public ActionResult Index(string filter = "")
        {
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            IEnumerable<OfficeModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: Office/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel OfficeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (OfficeModel == null)
            {
                return HttpNotFound();
            }
            return View(OfficeModel);
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            IEnumerable<TownDTO> tlist = this._tApp.getRecordsList(string.Empty);
            TownGUIMapper tMapper = new TownGUIMapper();

            OfficeModel model = new OfficeModel()
            {
                TownList = tMapper.DTOToModelMapper(tlist),
            };
            return View(model);
        }

        // POST: Office/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,Phone,Latitude,Longitude,IdTown,Address")] OfficeModel OfficeModel)
        {
            if (ModelState.IsValid)
            {
                OfficeGUIMapper mapper = new OfficeGUIMapper();
                OfficeDTO response = _app.createRecord(mapper.ModelToDTOMapper(OfficeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(OfficeModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(OfficeModel);
        }

        // GET: Office/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel OfficeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<TownDTO> tlist = this._tApp.getRecordsList(string.Empty);
            TownGUIMapper tMapper = new TownGUIMapper();

            OfficeModel.TownList = tMapper.DTOToModelMapper(tlist);

            if (OfficeModel == null)
            {
                return HttpNotFound();
            }
            return View(OfficeModel);
        }

        // POST: Office/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,Phone,Latitude,Longitude,IdTown,Address")] OfficeModel OfficeModel)
        {
            if (ModelState.IsValid)
            {
                OfficeGUIMapper mapper = new OfficeGUIMapper();
                OfficeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(OfficeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(OfficeModel);
        }

        // GET: Office/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel OfficeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (OfficeModel == null)
            {
                return HttpNotFound();
            }
            return View(OfficeModel);
        }

        // POST: Office/Delete/5
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