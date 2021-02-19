using Force.Ddd;

namespace AbdtPractice.Core.Entities
{
    public class OrderSpecs
    {
        public Spec<Order> ByUserName(string userName)
        {
            return new(x => x.User.UserName == userName);
        }
    }
}