using System;
using System.Linq;
using System.Web.Mvc;
using HSMVC.DataAccess;

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
            throw new NotImplementedException();
        }
    }
}