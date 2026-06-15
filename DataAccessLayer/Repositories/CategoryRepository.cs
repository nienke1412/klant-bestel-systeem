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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MatrixIncDbContext _context;

        public CategoryRepository(MatrixIncDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.Include(c => c.Products);
        }

        public Category? GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void AddProductToCategory(int productId)
        {
            int CategoryId = 1; // voorbeeld category ID, moet dynamisch worden.
            var product = _context.Products.Find(productId);
            var category = _context.Categories.Find(CategoryId);
            category.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
