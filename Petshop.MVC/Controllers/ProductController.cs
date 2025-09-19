using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petshop.BLL.Services.Contracts;
using Petshop.BLL.ViewModels;
using Petshop.DAL.DataContext.Entities;

namespace Petshop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;
        private readonly UserManager<AppUser> _userManager;
        
        public ProductController(IProductService productService, IReviewService reviewService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _reviewService = reviewService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Details(string id)
        {
            int productId = int.Parse(id.Split('-').Last());
            //id.Substring(id.LastIndexOf('-')+1);
            var model = await _productService.GetAsync(predicate: x => x.Id == productId && !x.IsDeleted,
                include:
                x => x
                .Include(x => x.Category!)
                .Include(x => x.Images)
                .Include(x => x.ProductTags).ThenInclude(x => x.Tag!)
                .Include(x => x.Reviews.Where(x => x.ReviewStatus == ReviewStatus.Approve)).ThenInclude(x => x.AppUser!));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(int id, CreateReviewViewModel createReviewViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", new { id = $"{createReviewViewModel.ProductId}" });
            }

            if (id != createReviewViewModel.ProductId)
            {
                return RedirectToAction("Details", new { id = $"{createReviewViewModel.ProductId}" });
            }

            if (User.Identity!.IsAuthenticated)
            {
                //createReviewViewModel.AppUserId = User.Claims.FirstOrDefault(x=>x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            
                var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
                createReviewViewModel.AppUserId = user!.Id;
            }

            createReviewViewModel.ReviewStatus = ReviewStatus.Pending;

            await _reviewService.CreateAsync(createReviewViewModel);

            return RedirectToAction("Details", new { id = $"{createReviewViewModel.ProductId}" });
        }
    }
}
