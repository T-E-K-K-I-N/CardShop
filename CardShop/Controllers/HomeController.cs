using CardShop.DAL.Interfaces;
using CardShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CardShop.Controllers
{
    public class HomeController : Controller
    { 

        public IActionResult Index()
        {
            return View();
        }

      
    }
}