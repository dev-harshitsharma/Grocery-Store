namespace Core.Entities.OrderAggregate
{
    //This class is responsible for the schema of the Order that has been placed by the user
    public class Order:BaseEntity
    {
        public Order()
        {
        }
        public Order(IReadOnlyList<OrderItem> orderItems,string buyerEmail, decimal subTotal)
        {
          
            BuyerEmail = buyerEmail;
            OrderItems = orderItems;
            SubTotal = subTotal;
        }

        public string BuyerEmail {get;set;}

        public DateTime OrderDate {get;set;} = DateTime.UtcNow;

        public IReadOnlyList<OrderItem> OrderItems {get;set;}

        public decimal SubTotal {get;set;}

        public decimal GetTotal(){
            return SubTotal;
        }
    }
}