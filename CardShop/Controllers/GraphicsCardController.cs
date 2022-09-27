using CardShop.DAL.Interfaces;
using CardShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardShop.Controllers
{
    public class GraphicsCardController : Controller
    {

        private readonly IGraphicsCardService _graphicsCardService;

        public GraphicsCardController(IGraphicsCardService graphicsCardService)
        {
            _graphicsCardService = graphicsCardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGraphicsCard()
        {
            var response = await _graphicsCardService.GetGraphicsCards();
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
