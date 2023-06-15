using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.DTOs.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class VehicleController : Controller
    {
        private IVehicleApplication _app = new VehicleApplication();
        private ITransportTypeApplication _ttApp = new TransportTypeApplication();

        // GET: DocumentType
        public ActionResult Index(string filter = "")
        {
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            IEnumerable<VehicleModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: DocumentType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel vehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: DocumentType/Create
        public ActionResult Create()
        {
            IEnumerable<TransportTypeDTO> ttlist = this._ttApp.getRecordsList(string.Empty);
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            VehicleModel model = new VehicleModel()
            {
                TransportTypeList = mapper.DTOToModelMapper(ttlist),
            };
            return View(model);
        }

        // POST: DocumentType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Placa,IdTransportType")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                VehicleGUIMapper mapper = new VehicleGUIMapper();
                VehicleDTO response = _app.createRecord(mapper.ModelToDTOMapper(vehicleModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(vehicleModel);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(vehicleModel);
        }

        // GET: DocumentType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel vehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<TransportTypeDTO> ttlist = this._ttApp.getRecordsList(string.Empty);
            TransportTypeGUIMapper ttmapper = new TransportTypeGUIMapper();

            vehicleModel.TransportTypeList = ttmapper.DTOToModelMapper(ttlist);

            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: DocumentType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Placa,IdTransportType")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                VehicleGUIMapper mapper = new VehicleGUIMapper();
                VehicleDTO response = _app.updateRecord(mapper.ModelToDTOMapper(vehicleModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(vehicleModel);
        }

        // GET: DocumentType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel vehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: DocumentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool response = _app.deleteRecordById(id);
            if (response)
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View();
        }
    }
}