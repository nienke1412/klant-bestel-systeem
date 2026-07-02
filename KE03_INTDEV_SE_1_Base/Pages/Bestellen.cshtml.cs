using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class BestellenModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public Order Order { get; set; }

        public BestellenModel(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }
        

        public IActionResult OnPostBetalen(int CustomerId)
        {
            int orderId = 1; // order moet nog worden gekoppeld aan de juiste klant, dit is nu hardcoded voor test doeleinden
            _customerRepository.AddOrderToCustomer(orderId);
            return RedirectToPage("/Betaalt");
        }

        public decimal totaalbedrag { get; set; }
        public decimal totaalVerzendBedrag { get; set; }

        public void OnGet()
        {
            int orderId = 1;
            Order = _orderRepository.GetOrderById(orderId);
            decimal totaalbedrag = 0;
            decimal totaalVerzendBedrag = 0;
            foreach (var item in Order.Products)
            {
                var price = item.Price;
                totaalbedrag += price;
            }
            this.totaalbedrag = totaalbedrag;
            totaalVerzendBedrag = totaalbedrag + 3.95m;
            this.totaalVerzendBedrag = totaalVerzendBedrag;
        }
    }
}
