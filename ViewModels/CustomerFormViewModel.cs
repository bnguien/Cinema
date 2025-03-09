using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCApp.Models;

namespace MyMVCApp.ViewModels
{

    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType>? MembershipTypes { get; set; }
        public MyMVCApp.Models.Customer Customer { get; set; } = new MyMVCApp.Models.Customer(); 
    }
}
