using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service;

public class CategoryRepo : ICategoryRepo
{
    private MainContext MainContext;

    public CategoryRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Category> AddAsync(Category obj)
    {
        await MainContext.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long id)
    {
        var remove = await GetbyIdAsync(id);
        MainContext.Remove(remove);
        await MainContext.SaveChangesAsync();
    }

    public IQueryable<Category> GetAll()
    {
        var res = MainContext.Categories;
        return res;
    }

    public async Task<Category> GetbyIdAsync(long id)
    {
        var res = await MainContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (res == null)
        {
            throw new Exception($"Category not found {id}");
        }
        return res;
    }

    public async Task UpdateAsync(Category obj)
    {
        var update = await GetbyIdAsync(obj.Id);
        MainContext.Update(obj);
        await MainContext.SaveChangesAsync();
    }
}
