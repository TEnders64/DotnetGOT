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
    public class CharactersController : Controller
    {
        private GOTcontext _context;

        public CharactersController(GOTcontext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("Characters")]
        public IActionResult Index()
        {
            CharacterViewModel model= new CharacterViewModel();
            ViewBag.AllHouses = _context.houses;
            return View(model);
        }

        [HttpPost]
        [Route("Characters/Create")]
        public IActionResult Create(CharacterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Character newCharacter = new Character{
                    Name = model.Name,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    HouseId = model.HouseId
                };

                _context.characters.Add(newCharacter);
                _context.SaveChanges();
                return RedirectToAction("AllCharacters");
            }
            ViewBag.AllHouses = _context.houses;
            return View("Index", model);
        }

        [HttpGet]
        [Route("Characters/AllCharacters")]
        public IActionResult AllCharacters()
        {
            ViewBag.AllCharacters = _context.characters.Include(character => character.House).ToList();
            return View();
        }

        [HttpGet]
        [Route("Characters/{id}")]
        public IActionResult DisplayCharacter(int id)
        {
            ViewBag.Character = _context.characters.Include(character => character.House).SingleOrDefault(character => character.Id == id);
            return View();
        }
    }
}
