namespace Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
    //This class is responsible for the schema of the Order that has been placed by the user

        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
     
        }

        public ProductItemOrdered ItemOrdered {get;set;}

        public decimal Price {get;set;}

        public int Quantity {get;set;}
        
    }
}