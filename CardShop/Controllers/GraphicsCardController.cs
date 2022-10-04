using CardShop.DAL.Interfaces;
using CardShop.Domain.ViewModels.GraphicsCard;
using CardShop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetGraphicsCards()
        {
            var response = await _graphicsCardService.GetGraphicsCards();
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetGraphicsCard(int id)
        {
            var response = await _graphicsCardService.GetGraphicsCard(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetGraphicsCardByTitle(string title)
        {
            var response = await _graphicsCardService.GetGraphicsCardByTitle(title);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _graphicsCardService.DeleteGraphicsCard(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetGraphicsCards");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _graphicsCardService.GetGraphicsCard(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(GraphicsCardViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    
                     await _graphicsCardService.CreateGraphicsCard(model);
                }
                else
                {
                    await _graphicsCardService.Edit(model.Id, model);
                }
            }
            return RedirectToAction("GetGraphicsCards");
        }
    }
}
