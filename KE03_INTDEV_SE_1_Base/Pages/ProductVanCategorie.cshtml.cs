using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class ProductVanCategorieModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductVanCategorieModel> _logger;
        private readonly IOrderRepository _orderRepository;

        public IList<Product> Products { get; set; }
        public List<string> Categorie { get; set; }

        public ProductVanCategorieModel(ILogger<ProductVanCategorieModel> logger, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            Products = new List<Product>();
            
        }
        public void OnGet(int categoryId)
        {
            Products = _productRepository.GetAllProductsByCategory(categoryId).ToList();
        }

        public IActionResult OnPostAddToCart(int productId)
        {
            int orderId = 1; // moet nog dynamisch worden maar weet nogsteeds niet hoe
            _orderRepository.AddProductToOrder(orderId, productId);
            return RedirectToPage();
        }

    }
}
