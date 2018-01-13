using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoreKeeper.Models;
using ScoreKeeper.Data;
using Microsoft.EntityFrameworkCore;

namespace ScoreKeeper.Controllers
{
    
    public class PlayerController : Controller
    {
       
        public readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }
        
       
        public IActionResult Index()
        {
            var model = _context.Players.ToList();
            
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var model = _context.Players.Include(e => e.Scores).FirstOrDefault(e => e.id == id);
            return View(model);
        }
    }

}