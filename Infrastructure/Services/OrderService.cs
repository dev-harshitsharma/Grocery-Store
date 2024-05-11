using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Entities;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {

        private readonly IBasketRepository basketRepo;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork,
        IBasketRepository basketRepo)
        {
            this.unitOfWork = unitOfWork;

            this.basketRepo = basketRepo;

        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, string basketId)
        {
            //get basket from basket repo
            var basket = await basketRepo.GetBasketAsync(basketId);

            //get items from the product repo 
            var items = new List<OrderItem>();
            
            foreach (var item in basket.Items)
            {

                var productItem = await unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.ImageUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);

                items.Add(orderItem);
            }


            var subtotal = items.Sum(item => item.Price * item.Quantity);


            var order = new Order(items, buyerEmail, subtotal);

            unitOfWork.Repository<Order>().Add(order);

            var result = await unitOfWork.Complete();

            if(result <= 0) return null;
            
      
            await basketRepo.DeleteBasketAsync(basketId);

     
            return order;


        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id,buyerEmail);

            return await unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);

            return await unitOfWork.Repository<Order>().ListAsync(spec);
        }
    }
}