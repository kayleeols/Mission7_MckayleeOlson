using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //This will Figure out how many pages we need
        public int TotalPages => (int)Math.Ceiling((double)TotalNumProjects / ProjectsPerPage);
    }
}
