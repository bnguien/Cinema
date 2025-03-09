using Microsoft.AspNetCore.Mvc;
using MyMVCApp.Models;
using System;
using System.Collections.Generic;
namespace MyMVCApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var contact = new Contact() { Id = 1, Name = "Bao Nguyen", Email = "nguyennguyendangbao8@gmail.com", Message = "Hello, I am Bao Nguyen. Can i help you?" };
            return View(contact);
        }
    }
}