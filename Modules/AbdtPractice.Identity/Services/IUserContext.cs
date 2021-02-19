using AbdtPractice.Identity.Entities;
using JetBrains.Annotations;

namespace AbdtPractice.Identity.Services
{
    public interface IUserContext
    {
        [CanBeNull]
        public User User { get; }

        public bool IsAuthenticated => User != null;
    }
}