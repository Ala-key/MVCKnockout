using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using MVCKnockout.DAL;
using MVCKnockout.Models;

namespace MVCKnockout.Controllers
{
    public class PeopleController: Controller
    {
        private readonly PeopleDbContext _context;

        public PeopleController(PeopleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var peoples = _context.Peoples.ToList();
            return View(peoples);
        }


        [HttpPost]
        public IActionResult Create([FromBody]People people)
        {
            if (people.Email != null && people.Password != null)
            {
                _context.Peoples.Add(people);
                _context.SaveChanges();
            }
            return View();
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View(new People());
        }

    }
}
