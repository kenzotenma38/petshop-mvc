using Microsoft.AspNetCore.Mvc;
using Petshop.BLL.Services.Contracts;

namespace Petshop.MVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IFooterService _footerService;

        public FooterViewComponent(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _footerService.GetFooterViewModelAsync();
            return View(model);
        }
    }
}


