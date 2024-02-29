using Domain.Enums;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public ProductStatus Status { get; private set; }
        public int Quantity { get; private set; }

        public void SetName(string newName) => Name = newName;
        public void SetDescription(string newDescription) => Description = newDescription;
        public void SetStatus(ProductStatus newStatus) => Status = newStatus;
        public void SetQuantity(int quantity) => Quantity = quantity;
}
}
