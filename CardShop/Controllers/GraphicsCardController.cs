using CardShop.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardShop.Controllers
{
    public class GraphicsCardController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetGraphicsCard()
        {
            return View();
        }
    }
}
