using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class BestellenModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;

        public BestellenModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult OnPostBetalen(int CustomerId)
        {
            int orderId = 1; // order moet nog worden gekoppeld aan de juiste klant, dit is nu hardcoded voor test doeleinden
            _customerRepository.AddOrderToCustomer(orderId);
            return RedirectToPage("/Betaalt");
        }

        public void OnGet()
        {
        }
    }
}
