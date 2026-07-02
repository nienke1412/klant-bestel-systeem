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
