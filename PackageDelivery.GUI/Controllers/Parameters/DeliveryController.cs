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
    public class DeliveryController : Controller
    {
        private IDeliveryApplication _app = new DeliveryImpApplication();

        // GET: Delivery
        public ActionResult Index(long filter)
        {
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            IEnumerable<DeliveryModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: Delivery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            DeliveryModel deliveryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // GET: Delivery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Delivery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SendDate,Price,IdSender,IdAddressDestination,IdPackage,IdDeliveryState,IdTransportType")] DeliveryModel deliveryModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryGUIMapper mapper = new DeliveryGUIMapper();
                DeliveryDTO response = _app.createRecord(mapper.ModelToDTOMapper(deliveryModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(deliveryModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(deliveryModel);
        }

        // GET: Delivery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            DeliveryModel deliveryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // POST: Delivery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SendDate,Price,IdSender,IdAddressDestination,IdPackage,IdDeliveryState,IdTransportType")] DeliveryModel deliveryModel)
        {
            if (ModelState.IsValid)
            {
                DeliveryGUIMapper mapper = new DeliveryGUIMapper();
                DeliveryDTO response = _app.updateRecord(mapper.ModelToDTOMapper(deliveryModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(deliveryModel);
        }

        // GET: Delivery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryGUIMapper mapper = new DeliveryGUIMapper();
            DeliveryModel deliveryModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // POST: Delivery/Delete/5
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


    