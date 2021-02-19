using AbdtPractice.Core.Entities;

namespace AbdtPractice.Core.Services
{
    public interface ICartStorage
    {
        Cart Cart { get; }
        void SaveChanges();
        void EmptyCart();
    }
}