using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class ProductPaginaModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductPaginaModel> _logger;

        public IList<Product> Products { get; set; }

        public ProductPaginaModel(ILogger<ProductPaginaModel> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            Products = new List<Product>();
        }

        public void OnGet()
        {
            Products = _productRepository.GetAllProducts().ToList();
            _logger.LogInformation($"getting all {Products.Count} products");
        }
    }
}
