using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models.ViewModels
{
    public class BookViewModel
    {
        public IQueryable<Books> Books { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}
