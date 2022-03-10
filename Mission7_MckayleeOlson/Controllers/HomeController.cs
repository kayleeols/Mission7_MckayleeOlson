using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using Mission7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        private IMission7Repository repo;

        public HomeController(IMission7Repository temp)
        {
            repo = temp;
        }

        //private BookstoreContext context { get; set; }
        //public HomeController(BookstoreContext temp) => context = temp;


        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BookViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
