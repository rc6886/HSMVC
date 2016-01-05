using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using HSMVC.Controllers.Commands;
using HSMVC.DataAccess;
using HSMVC.Domain;

namespace HSMVC.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository _repository;

        public ConferenceController(IConferenceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var conferences = _repository.GetAll().ToList();
            return View(conferences);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var conference = _repository.Load(id);
            var command = Mapper.Map<ConferenceEditCommand>(conference);
            return View(command);
        }

        [HttpPost]
        public ActionResult Edit(ConferenceEditCommand command)
        {
            if (!ModelState.IsValid) return View(command);

            var conference = _repository.Load(command.Id);
            conference.ChangeName(command.Name);
            conference.ChangeCost(command.Cost);
            conference.ChangeDates(command.StartDate.Value, command.EndDate.Value);
            _repository.Save(conference);
            return RedirectToAction("Index");
        }
    }
}