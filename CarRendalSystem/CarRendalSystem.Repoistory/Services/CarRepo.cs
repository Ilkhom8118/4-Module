using CarRendalSystem.Dal;
using CarRendalSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRendalSystem.Repoistory.Services
{
    public class CarRepo : ICarRepo
    {
        private MainContext MainContext;

        public CarRepo(MainContext mainContext)
        {
            MainContext = mainContext;
        }

        public async Task<Car> AddAsync(Car obj)
        {
            await MainContext.Cars.AddAsync(obj);
            await MainContext.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteAsync(long id)
        {
            var byId = await GetByIdAsync(id);
            MainContext.Remove(byId);
            await MainContext.SaveChangesAsync();
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await MainContext.Cars.ToListAsync();
        }

        public async Task<Car> GetByIdAsync(long id)
        {
            var obj = await MainContext.Cars.FirstOrDefaultAsync(b => b.Id == id);
            if (obj == null)
            {
                throw new Exception($"Not found Id : {id}");
            }
            return obj;
        }

        public async Task UpdateAsync(Car obj)
        {
            var byId = GetByIdAsync(obj.Id);
            MainContext.Update(obj);
            await MainContext.SaveChangesAsync();
        }
    }
}
