using Exam.Logic;

namespace Exam.Exception
{
    public class InactiveProductException : System.Exception
    {
        public User User { get; }
        public Product Product { get; }

        public InactiveProductException(User user, Product product)
            : base($"{user} tried purchasing {product} which is inactive")
        {
            User = user;
            Product = product;
        }
    }
}
