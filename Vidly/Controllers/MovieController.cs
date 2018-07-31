﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        // GET: Movie
        public ActionResult Index()
        {
            var moves = _context.Movies.Include(g => g.Genre).ToList();
            return View(moves);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if(movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Include(g=>g.Genre).Single(m=>m.Id == movie.Id);
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null) return HttpNotFound();
         
            
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            

            return View("MovieForm", viewModel);
        }
    }
}