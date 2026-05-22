using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MatrixIncDbContext _context;

        public OrderRepository(MatrixIncDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.Customer);
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.Include(o => o.Customer).Include(o => o.Products).FirstOrDefault(o => o.Id == id);
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void AddProductToOrder(int orderId, int productId)
        {
            var order = _context.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == orderId);
            var product = _context.Products.Find(productId);
            order.Products.Add(product);
            _context.SaveChanges();

        }

        public void NewOrder(string CustomerName)
        {
            var customer = _context.Customers
        .FirstOrDefault(c => c.Name == CustomerName);

            if (customer == null)
                throw new Exception("Customer not found");
            var order = new Order
            {
                CustomerId = customer.Id,
                OrderDate = DateTime.Now
            };
        }


    }
}
