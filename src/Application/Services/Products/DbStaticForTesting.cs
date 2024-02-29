using Domain.Entities;

namespace Application.Services.Products
{
    public static class DbStaticForTesting
    {
        public static List<Product> products { get; set; } = new List<Product>();
    }
}
