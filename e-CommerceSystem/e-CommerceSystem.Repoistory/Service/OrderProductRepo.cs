
using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service;

public class OrderProductRepo : IOrderProductRepo
{
    private MainContext MainContext;

    public OrderProductRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<OrderProduct> AddAsync(OrderProduct obj)
    {
        await MainContext.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long orderId, long productId)
    {
        var remove = await GetByIdAsync(orderId, productId);
        MainContext.Remove(remove);
        await MainContext.SaveChangesAsync();
    }

    public IQueryable<OrderProduct> GetAll()
    {
        var list = MainContext.OrderProducts;
        return list;
    }

    public async Task<OrderProduct> GetByIdAsync(long orderId, long productId)
    {
        var byId = await MainContext.OrderProducts.FirstOrDefaultAsync(op => op.OrderId == orderId && op.ProductId == productId);
        if (byId == null)
        {
            throw new Exception($"Order not found : {orderId}, Poduct not found {productId}");
        }
        return byId;
    }

    public async Task UpdateAsync(OrderProduct obj)
    {
        var byId = await GetByIdAsync(obj.OrderId, obj.ProductId);
        MainContext.Update(byId);
        await MainContext.SaveChangesAsync();
    }
}
