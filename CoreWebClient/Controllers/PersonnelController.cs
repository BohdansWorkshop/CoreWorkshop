using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsAndInterfaces.Interfaces;
using MongoDB.Bson;

namespace CoreWebClient.Controllers
{
    public class PersonnelController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonnelController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IActionResult Index()
        {
            var allPersons = _personRepository.GetAll().ToList();
            return View(allPersons);
        }
        public ActionResult Details(string personId)
        {
            return View();
            //return PartialView("_Details", _personRepository.Single(x => x.Id == ObjectId.Parse(personId)));
        }
    }
}