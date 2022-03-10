using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission7.Infrastructure;
using Mission7.Models;

namespace Mission7.Pages
{
    public class BasketModel : PageModel
    {
        //Creating a private instance of our IMission7Repository
        private IMission7Repository repo { get; set; }

        //Constructor for BasketModel --> Builds the instance of the database for you
        public BasketModel (IMission7Repository temp)
        {
            repo = temp;
        }
        
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            //Build and instance of a book model called b
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            //Once we have the project id we can add it to our basket
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }

}
