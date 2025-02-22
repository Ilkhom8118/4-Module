using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service
{
    public class ProductRepo : IProductRepo
    {
        private MainContext MainContext;

        public ProductRepo(MainContext mainContext)
        {
            MainContext = mainContext;
        }

        public async Task<Product> AddAsync(Product obj)
        {
            await MainContext.AddAsync(obj);
            await MainContext.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteAsync(long id)
        {
            var guid = await GetByIdAsync(id);
            MainContext.Remove(guid);
            await MainContext.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll()
        {
            var all = MainContext.Products;
            return all;

        }

        public async Task<Product> GetByIdAsync(long id)
        {
            var res = await MainContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (res == null)
            {
                throw new Exception($"Product not found {id}");
            }
            return res;
        }

        public async Task UpdateAsync(Product obj)
        {
            var existingProduct = await GetByIdAsync(obj.Id);
            if (existingProduct == null)
            {
                throw new Exception($"Product not found {obj.Id}");
            }

            MainContext.Entry(existingProduct).CurrentValues.SetValues(obj);
            await MainContext.SaveChangesAsync();
        }
    }
}
