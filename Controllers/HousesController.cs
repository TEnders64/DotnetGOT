using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EntityCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityCRUD.Controllers
{
    public class HousesController : Controller
    {
        private GOTcontext _context;

        public HousesController(GOTcontext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HouseViewModel model= new HouseViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(HouseViewModel model)
        {
            if (ModelState.IsValid)
            {
                House newHouse = new House{
                    Name = model.Name,
                    Sigil = model.Sigil,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Houses.Add(newHouse);
                _context.SaveChanges();
                return RedirectToAction("AllHouses");
            }
            return View("Index", model);
        }

        [HttpGet]
        [Route("AllHouses")]
        public IActionResult AllHouses()
        {
            ViewBag.AllHouses = _context.Houses.ToList();
            return View();
        }

        [HttpGet]
        [Route("Houses/{id}")]
        public IActionResult DisplayHouse(int id)
        {
            ViewBag.House = _context.Houses.Include(house => house.Characters).SingleOrDefault(house => house.Id == id);
            return View();
        }
    }
}
