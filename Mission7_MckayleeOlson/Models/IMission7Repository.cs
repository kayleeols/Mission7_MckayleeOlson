using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public interface IMission7Repository //HAS to be an INTERFACE
    {
        IQueryable<Books> Books { get; }
    }
}
