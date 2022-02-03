using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission5Movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Mission5Movies.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext MovieEntryContext { get; set; }

        public HomeController(MovieContext NewMovieContext)
        {
            MovieEntryContext = NewMovieContext;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = MovieEntryContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieEntry me)
        {
            //If all the restrictions specified in the model are met, then save it. Otherwise, display the unmet specification.
            if (ModelState.IsValid)
            {
                MovieEntryContext.Add(me);
                MovieEntryContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = MovieEntryContext.Categories.ToList();
                return View(me);
            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var films = MovieEntryContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(films);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = MovieEntryContext.Categories.ToList();

            var film = MovieEntryContext.Responses.Single(x => x.MovieId == movieid);
            return View("MovieForm", film);
        }

        [HttpPost]
        public IActionResult Edit(MovieEntry Updates)
        {
            if (ModelState.IsValid)
            {
                MovieEntryContext.Update(Updates);
                MovieEntryContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = MovieEntryContext.Categories.ToList();
                return View("MovieForm", Updates);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var application = MovieEntryContext.Responses.Single(x => x.MovieId == movieid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry mr)
        {
            MovieEntryContext.Responses.Remove(mr);
            MovieEntryContext.SaveChanges();
            return RedirectToAction("MovieList");
        }









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
