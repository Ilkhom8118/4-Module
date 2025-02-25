namespace e_CommerceSystem_.Dal.Enums
{
    public enum OrderStatus
    {
        Pending = 0,      // ⏳ Buyurtma qabul qilindi, lekin hali bajarilmagan
        Processing = 1,   // 🔄 Buyurtma ishlov berilmoqda
        Shipped = 2,      // 🚚 Buyurtma jo‘natildi
        Delivered = 3,    // ✅ Buyurtma yetkazib berildi
        Canceled = 4      // ❌ Buyurtma bekor qilindi
    }       
}
