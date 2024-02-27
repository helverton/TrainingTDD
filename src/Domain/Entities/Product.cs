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

        public Product(string name, string description)
        {
            Name = name;
            Description = description;
            Status = ProductStatus.Ativo;
            Quantity = 0;
        }

        public void UpdateName(string newName) => Name = newName;
        public void UpdateDescription(string newDescription) => Description = newDescription;
        public void UpdateStatus(ProductStatus newStatus) => Status = newStatus;
        public void UpdateQuantity(int quantity) => Quantity = Quantity + quantity;
    }
}
