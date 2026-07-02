using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class ProductPaginaModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public List<string> Categorie { get; set; }

        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductPaginaModel> _logger;
        private readonly IOrderRepository _orderRepository;

        public IList<Product> Products { get; set; }
        public IList<Product> FilteredProducts { get; set; }

        public ProductPaginaModel(ILogger<ProductPaginaModel> logger, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            Products = new List<Product>();

        }

        public void OnGet()
        {
            var ids = Categorie?.Select(int.Parse).ToList();
            Products = _productRepository.GetAllProducts().ToList();
            if (ids != null && ids.Any())
            {
                FilteredProducts = Products
                    .Where(p => ids.Contains(p.CategoryId))
                    .ToList();
            }
            else
            {
                FilteredProducts = Products;
            }
        }

        public IActionResult OnPostAddToCart(int productId)
        {
            int orderId = 1; // moet nog dynamisch worden maar weet nogsteeds niet hoe
            _orderRepository.AddProductToOrder(orderId, productId);

            TempData["Message"] = "Product toegevoegd aan winkelwagen!";

            return RedirectToPage();
        }

    }
}
