using Microsoft.AspNetCore.Mvc;
using Petshop.BLL.Services;

namespace Petshop.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly BasketManager _basketManager;

        public BasketController(BasketManager basketManager)
        {
            _basketManager = basketManager;
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            _basketManager.AddToBasket(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _basketManager.RemoveFromBasket(id);
            return NoContent();
        }

        public async Task<IActionResult> GetBasket()
        {
            var model = await _basketManager.GetBasketAsync();

            return Json(model);
        }
    }
}
