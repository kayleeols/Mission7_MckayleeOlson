using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class TypesViewComponent : ViewComponent
    {
        //This is not referencing the other repository, this is it's own repository with it's own stuff
        private IMission7Repository repo { get; set; }

        public TypesViewComponent (IMission7Repository temp)
        {
            repo = temp;
        }
        //When the compoenet is invoked, it will return something
        public IViewComponentResult Invoke()
        {
            //This allows us to get the project type from the route
            ViewBag.SelectedType = RouteData?.Values["bookCategory"];

            //build our little data set here
            var types = repo.Books
                .Select(x => x.Classification)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
