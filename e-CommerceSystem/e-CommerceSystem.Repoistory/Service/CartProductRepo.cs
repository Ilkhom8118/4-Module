using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service;

public class CartProductRepo : ICartProductRepo
{
    private MainContext MainContext;

    public CartProductRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<CartProduct> AddAsync(CartProduct obj)
    {
        await MainContext.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long cartId, long productId)
    {
        var guid = await GetByIdAsync(cartId, productId);
        MainContext.Remove(guid);
        await MainContext.SaveChangesAsync();
    }

    public IQueryable<CartProduct> GetAll()
    {
        var list = MainContext.CartProducts;
        return list;
    }

    public async Task<CartProduct> GetByIdAsync(long cartId, long productId)
    {
        var res = await MainContext.CartProducts.FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);
        if (res == null)
        {
            throw new Exception($"Cart not found: {cartId},Product not found : {productId}");
        }
        return res;
    }

    public async Task UpdateAsync(CartProduct cart, CartProduct product)
    {
        var obj = await GetByIdAsync(cart.CartId, product.ProductId);
        MainContext.Update(obj);
        await MainContext.SaveChangesAsync();
    }
}
