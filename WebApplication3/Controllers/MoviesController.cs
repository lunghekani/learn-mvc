using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {MovieName = "Batman"};


         //   return View(Movie);
         //return Content("hello world");
         //return HttpNotFound();
         //return new EmptyResult();

         var customers = new List<Customer>
         {
             new Customer {Name="Customer 1"},
             new Customer{Name = "Customer 2"}
         };

         var viewModel = new RandomMovieViewModel
         {
             Movie = movie,
             Customers = customers
         };

         return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        // list of movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }

            return Content(string.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));

        }
        //movies by release year
        [Route("movies/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+ month);
        }
        
    }
}