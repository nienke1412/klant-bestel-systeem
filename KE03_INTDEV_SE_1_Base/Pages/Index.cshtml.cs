using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICategoryRepository _categoryRepository;
        

        public IList<Customer> Customers { get; set; }
        public IList<Category> Categories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ICustomerRepository customerRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _categoryRepository = categoryRepository;
            Categories = new List<Category>();
            Customers = new List<Customer>();
        }

        public void OnGet()
        {            
            Customers = _customerRepository.GetAllCustomers().ToList();
            Categories = _categoryRepository.GetAllCategories().ToList();
            _logger.LogInformation($"getting all {Customers.Count} customers");
        }

        
    }
}
