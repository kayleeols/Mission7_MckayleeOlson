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
        public BasketModel (IMission7Repository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            //Build and instance of a book model called b
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            //Once we have the project id we can add it to our basket
            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }

}
