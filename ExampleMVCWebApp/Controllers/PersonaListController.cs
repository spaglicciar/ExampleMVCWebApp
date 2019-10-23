using ExampleMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleMVCWebApp.Controllers
{
    public class PersonaListController : Controller
    {
        private static List<PersonaViewModel> _model;

        // GET: PersonaList
        public ActionResult Index()
        {
            ViewBag.Message = "Your list of persona";

            if (_model == null)
            {
                _model = new List<PersonaViewModel>
                {
                    new PersonaViewModel{Cognome= "Spagliccia", Nome = "Roberto", DataDiNascita = new DateTime(1983,7,3), PersonaId = PersonaViewModel.NextId},
                    new PersonaViewModel{Cognome= "Baggio", Nome = "Roberto", DataDiNascita = new DateTime(1983,4,5), PersonaId = PersonaViewModel.NextId},
                };
            }
            return View(_model);
        }

        // GET: PersonaList/Details/5
        public ActionResult Details(int id)
        {
            var personaDetails = _model.Where(p => p.PersonaId == id).FirstOrDefault();
            return View(personaDetails);
        }

        // GET: PersonaList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaList/Create
        [HttpPost]
        public ActionResult Create(PersonaViewModel personaToAdd)
        {
            try
            {
                // TODO: Add insert logic here
                personaToAdd.PersonaId = PersonaViewModel.NextId;
                _model.Add(personaToAdd);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaList/Edit/5
        public ActionResult Edit(int id)
        {
            var persona = _model.Where(p => p.PersonaId == id).FirstOrDefault();
            return View(persona);
        }

        // POST: PersonaList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonaViewModel model)
        {
            try
            {
                // NB: Persona è una class -> reference type -> se modifico personaToEdit modifico anche l'oggetto in lista
                var personaToEdit = _model.Where(p => p.PersonaId == id).FirstOrDefault();
                personaToEdit.PersonaId = model.PersonaId;
                personaToEdit.Nome = model.Nome;
                personaToEdit.Cognome = model.Cognome;
                personaToEdit.DataDiNascita = model.DataDiNascita;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaList/Delete/5
        public ActionResult Delete(int id)
        {
            var persona = _model.Where(p => p.PersonaId == id).FirstOrDefault();
            return View(persona);
        }

        // POST: PersonaList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var persona = _model.Where(p => p.PersonaId == id).FirstOrDefault();
                _model.Remove(persona);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
