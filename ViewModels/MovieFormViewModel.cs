using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCApp.Models;

namespace MyMVCApp.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; } = new Movie();
    }
}