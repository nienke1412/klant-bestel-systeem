using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class ProductPaginaModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductPaginaModel> _logger;
        private readonly IOrderRepository _orderRepository;

        public IList<Product> Products { get; set; }

        public ProductPaginaModel(ILogger<ProductPaginaModel> logger, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            Products = new List<Product>();

        }

        public void OnGet()
        {
            Products = _productRepository.GetAllProducts().ToList();
            _logger.LogInformation($"getting all {Products.Count} products");
        }

        public IActionResult OnPostAddToCart(int productId)
        {
            int orderId = 1; // In a real application, you would get the order ID from the user's session or database
            _orderRepository.AddProductToOrder(orderId, productId);
            return RedirectToPage();
        }

    }
}
