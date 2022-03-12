using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class InfoDonate
    {
        [Key]
        [BindNever]
        public int DonationId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a State:")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a Country:")]
        public string Country { get; set; }

        public bool Anonymous { get; set; }
    }
}
