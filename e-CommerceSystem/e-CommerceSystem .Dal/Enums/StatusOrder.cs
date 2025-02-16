namespace e_CommerceSystem_.Dal.Enums;

public enum StatusOrder
{
    Pending,        // Buyurtma qabul qilindi, ammo hali jarayonda
    Processing,     // Buyurtma qayta ishlanmoqda
    Shipped,        // Buyurtma yuborildi
    Delivered,      // Buyurtma yetkazib berildi
    Cancelled,      // Buyurtma bekor qilindi
    Returned        // Buyurtma qaytarib berildi
}
