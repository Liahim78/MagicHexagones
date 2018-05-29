using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MagicHexagonsServer.Models;

namespace MagicHexagonsServer.Controllers
{
    public class HomeController : Controller
    {
        MagicHexagonsContext db;
        public HomeController(MagicHexagonsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }
    }
}
