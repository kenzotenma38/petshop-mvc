using Microsoft.AspNetCore.Mvc;
using Petshop.BLL.Services.Contracts;

namespace Petshop.MVC.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IHeaderService _headerService;

        public HeaderViewComponent(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _headerService.GetHeaderViewModelAsync();
            return View(model);
        }
    }
}


