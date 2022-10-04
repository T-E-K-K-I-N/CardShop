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
        public IActionResult GetGraphicsCards()
        {
            var response = _graphicsCardService.GetGraphicsCards();
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> GetGraphicsCard(int id)
        {
            var response = await _graphicsCardService.GetGraphicsCard(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> GetGraphicsCardByTitle(string title)
        {
            var response = await _graphicsCardService.GetGraphicsCardByTitle(title);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error", $"{response.Description}");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _graphicsCardService.DeleteGraphicsCard(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetGraphicsCards");
            }
            return RedirectToAction("Error", $"{response.Description}");
        }

        public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return PartialView();
            }

            var response = await _graphicsCardService.GetGraphicsCard(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            ModelState.AddModelError("", response.Description);

            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(GraphicsCardViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                    }
                    await _graphicsCardService.CreateGraphicsCard(model, imageData);
                }
                else
                {
                    await _graphicsCardService.Edit(model.Id, model);
                }
                return RedirectToAction("GetGraphicsCards");
            }
            return View();
        }
    }
}
