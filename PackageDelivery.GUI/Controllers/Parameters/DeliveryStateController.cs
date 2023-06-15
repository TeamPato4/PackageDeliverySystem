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
    public class DeliveryStateController : Controller
    {
        private IDeliveryStateApplication _app = new DeliveryStateImpApplication();

        // GET: DeliveryState
        public ActionResult Index(string filter = "")
        {
            DeliveryStateGUIMapper mapper = new DeliveryStateGUIMapper();
            IEnumerable<DeliveryStateModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: DeliveryState/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStateGUIMapper mapper = new DeliveryStateGUIMapper();
            DeliveryStateModel deliveryStateModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (deliveryStateModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStateModel);
        }

        // GET: DeliveryState/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryState/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DeliveryStateModel deliveryStateModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryStateGUIMapper mapper = new DeliveryStateGUIMapper();
                DeliveryStateDTO response = _app.createRecord(mapper.ModelToDTOMapper(deliveryStateModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(deliveryStateModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(deliveryStateModel);
        }

        // GET: DeliveryState/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStateGUIMapper mapper = new DeliveryStateGUIMapper();
            DeliveryStateModel deliveryStateModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (deliveryStateModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStateModel);
        }

        // POST: DeliveryState/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DeliveryStateModel deliveryStateModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryStateGUIMapper mapper = new DeliveryStateGUIMapper();
                DeliveryStateDTO response = _app.updateRecord(mapper.ModelToDTOMapper(deliveryStateModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(deliveryStateModel);
        }

        // GET: DeliveryState/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStateGUIMapper mapper = new DeliveryStateGUIMapper();
            DeliveryStateModel deliveryStateModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (deliveryStateModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStateModel);
        }

        // POST: DeliveryState/Delete/5
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

 
