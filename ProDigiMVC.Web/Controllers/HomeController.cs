using Microsoft.AspNetCore.Mvc;
using ProDigiMVC.Web.Models;
using System.Diagnostics;

namespace ProDigiMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult ViewMainMenu()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult ViewListOfProducts()
        {
            ViewData["Title"] = "Lista dostępnych produktów";
            ViewBag.Test = "Testowy ViewBag";  // ViewBag możemy wykorzystać tylko do jednej akcji, ViewData możemy przesyłać dalej

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Kasli", Version = "2.0", Designer = "Jan Kowalski" },
                new Product() { Id = 2, Name = "Sampler", Version = "1.0", Designer = "Adam Kot" },
                new Product() { Id = 3, Name = "Urukul", Version = "2.4", Designer = "Michał Kichał" },
                new Product() { Id = 4, Name = "Zotino", Version = "1.7", Designer = "Mirek Nowak" },
                new Product() { Id = 5, Name = "Fastino", Version = "4.7", Designer = "Mirek Nowak" },
                new Product() { Id = 6, Name = "Mirny", Version = "3.7", Designer = "Mirek Nowak" },
                new Product() { Id = 7, Name = ViewBag.Test, Version = "3.7", Designer = "BagBag" },
            };
            return View(products);
        }

        public IActionResult ViewListOfOrders()
        {
            List<Order> orders = new List<Order>()
            {
                new Order() { Id = 1, OrderType = "Produkcyjne", ProductName = "Kasli", Company = "Elpro", Quantity = 100, Status = "Przyjęcie zlecenia" },
                new Order() { Id = 2, OrderType = "Reklamacyjne", ProductName = "Urukul", Company = "Elpro", Quantity = 33, Status = "Zrealizowane" },
                new Order() { Id = 3, OrderType = "Serwisowe", ProductName = "Fastino", Company = "Creo", Quantity = 49, Status = "W realizacji" },
                new Order() { Id = 4, OrderType = "Produkcyjne", ProductName = "Mirny", Company = "Invent", Quantity = 43, Status = "Przyjęcie zlecenia" },
                new Order() { Id = 5, OrderType = "Reklamacyjne", ProductName = "Sampler", Company = "Creo", Quantity = 100, Status = "Przyjęcie zlecenia" },
            };
            return View(orders);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}