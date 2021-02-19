using AbdtPractice.Core.Entities;
using AbdtPractice.Core.Services;
using Force.Ccc;
using Force.Cqrs;

namespace AbdtPractice.Shop.Features.MyOrders
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrder, int>
    {
        private readonly ICartStorage _cartStorage;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(
            ICartStorage cartStorage,
            IUnitOfWork unitOfWork)
        {
            _cartStorage = cartStorage;
            _unitOfWork = unitOfWork;
        }
        public int Handle(CreateOrder input)
        {
            var order = new Order(_cartStorage.Cart);

            _unitOfWork.Add(order);
            _unitOfWork.Commit();
            _cartStorage.EmptyCart();

            return order.Id;
        }
    }
}
