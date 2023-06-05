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
    public class TransportTypeController : Controller
    {
        private ITransportTypeApplication  _app = new TransportTypeApplication();

        // GET: DocumentType
        public ActionResult Index(string filter = "")
        {
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            IEnumerable<TransportTypeModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: DocumentType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel transportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
        }

        // GET: DocumentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TransportTypeModel transportTypeModel)
        {
            if (ModelState.IsValid)
            {
                TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
                TransportTypeDTO response = _app.createRecord(mapper.ModelToDTOMapper(transportTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(transportTypeModel);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(transportTypeModel);
        }

        // GET: DocumentType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel transportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
        }

        // POST: DocumentType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TransportTypeModel transportTypeModel)
        {
            if (ModelState.IsValid)
            {
                TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
                TransportTypeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(transportTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(transportTypeModel);
        }

        // GET: DocumentType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel transportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
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