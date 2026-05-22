using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class OrderHistoryModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        public Customer Customer { get; set; }

        public OrderHistoryModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void OnGet()
        {
            int CustomerId = 1;
            Customer = _customerRepository.GetCustomerById(CustomerId);
        }
    }
}
