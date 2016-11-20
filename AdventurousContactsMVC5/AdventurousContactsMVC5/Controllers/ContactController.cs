using AdventurousContactsMVC5.Models;
using AdventurousContactsMVC5.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdventurousContactsMVC5.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository;

        public ContactController(IRepository repository)
        {
            _repository = repository;
        }              

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }

        #region Index
        // GET: Contact
        public ActionResult Index()
        {
            try
            {
                return View(_repository.GetLastContacts(100));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName, LastName, EmailAddress")] Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(contact);
                    _repository.Save();
                    TempData["success"] = "was successfully created.";
                    return View("Success", contact);
                }
            }
            catch (Exception e)
            {
                TempData["error"] = e.InnerException.Message;
            }

            return View(contact);
        }
        #endregion

        #region Edit

        // Get
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = _repository.GetContactById(id.Value);

            if (contact == null)
            {
                return View("NotFound");
            }

            return View(contact);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Contact contact)
        {
            if (contact == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (TryUpdateModel(contact, new string[] { "Firstname", "Lastname", "EmailAddress" }))
            {
                try
                {
                    _repository.Update(contact);
                    _repository.Save();
                    TempData["success"] = "was successfully edited";
                    return View("Success", contact);                    
                }
                catch (DataException e)
                {
                    TempData["error"] = e.InnerException.InnerException.Message;
                }
            }

            return View(contact);
        }
        #endregion

        #region Delete

        // Get
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contact = _repository.GetContactById(id.Value);

            if (contact == null)
            {
                return View("NotFound");
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var contactToDelete = _repository.GetContactById(id);
                _repository.Delete(contactToDelete);
                _repository.Save();
                TempData["success"] = " was successfully deleted.";
                return View("Success", contactToDelete);
            }
            catch (DataException e)
            {
                TempData["error"] = e.InnerException.InnerException.Message;
                return RedirectToAction("Delete", new { id = id });
            }
        }

        #endregion
    }
}