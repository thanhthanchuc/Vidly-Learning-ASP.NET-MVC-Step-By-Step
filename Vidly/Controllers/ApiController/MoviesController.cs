using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTO;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.ApiController
{
    public class MoviesController : System.Web.Http.ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //get api/movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m=>m.Genre).ToList();
        }

        //get apt/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //post api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //put api/movie/1
        [HttpPut]
        public void PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<MovieDto, Movie>(movieDto);
            _context.SaveChanges();
        }

        //delete api/movie/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movie);
            _context.SaveChanges(); 
        }
    }
}
