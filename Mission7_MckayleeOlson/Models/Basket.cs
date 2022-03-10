using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Basket
    {
        //The first part declares the variable, the second part instantiates the variable
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Books bks, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == bks.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bks,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books Book { get; set; } //Instance of a Book named Book
        public int Quantity { get; set; } //How many of these books they want to add to their cart/basket
    }
}

