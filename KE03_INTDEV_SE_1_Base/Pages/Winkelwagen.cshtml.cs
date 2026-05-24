using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class WinkelwagenModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        public Order Order { get; set; }
        public WinkelwagenModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {
            int orderId = 1;
            Order = _orderRepository.GetOrderById(orderId);
        }

        public IActionResult OnPost(int CustomerId)
        {
            int orderId = 1; // order moet nog worden gekoppeld aan de juiste klant, dit is nu hardcoded voor test doeleinden
            _customerRepository.AddOrderToCustomer(orderId, CustomerId);
            return RedirectToPage("/Betaalt");
        }
    }
}
