﻿using PackageDelivery.Application.Contracts.Interfaces.Parameters;
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
    public class AddressController : Controller
    {
        private IAddressApplication _app = new AddressImpApplication();
        private IPersonApplication _pApp = new PersonImpApplication();
        private ITownApplication _tApp = new TownImpApplication();

        // GET: Address
        public ActionResult Index(string filter = "")
        {
            AddressGUIMapper mapper = new AddressGUIMapper();
            IEnumerable<AddressModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel addressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            IEnumerable<PersonDTO> plist = this._pApp.getRecordsList(string.Empty);
            PersonGUIMapper mapper = new PersonGUIMapper();

            IEnumerable<TownDTO> tlist = this._tApp.getRecordsList(string.Empty);
            TownGUIMapper tMapper = new TownGUIMapper();

            AddressModel model = new AddressModel()
            {
                PersonList = mapper.DTOToModelMapper(plist),
                TownList = tMapper.DTOToModelMapper(tlist),
            };
            return View(model);
        }

        // POST: Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StreetType,Number,PropertyType,Neighborhood,Observations,Current,IdTown,IdPerson")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                AddressGUIMapper mapper = new AddressGUIMapper();
                AddressDTO response = _app.createRecord(mapper.ModelToDTOMapper(addressModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(addressModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(addressModel);
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel addressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<PersonDTO> plist = this._pApp.getRecordsList(string.Empty);
            PersonGUIMapper pMapper = new PersonGUIMapper();
            IEnumerable<TownDTO> tlist = this._tApp.getRecordsList(string.Empty);
            TownGUIMapper tMapper = new TownGUIMapper();

            addressModel.PersonList = pMapper.DTOToModelMapper(plist);
            addressModel.TownList = tMapper.DTOToModelMapper(tlist);

            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // POST: Address/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StreetType,Number,PropertyType,Neighborhood,Observations,Current,IdTown,IdPerson")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                AddressGUIMapper mapper = new AddressGUIMapper();
                AddressDTO response = _app.updateRecord(mapper.ModelToDTOMapper(addressModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(addressModel);
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel addressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // POST: Address/Delete/5
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
