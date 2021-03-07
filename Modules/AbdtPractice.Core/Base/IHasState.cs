using AbdtPractice.Core.Entities;

namespace AbdtPractice.Core.Base
{
    public interface IHasState<T>
        where T : Order.OrderStateBase
    {
        T? State { get; }
    }
}