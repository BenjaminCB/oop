using Exam.Logic;

namespace Exam.Exception
{
    public class InsufficientCreditsExceptions : System.Exception
    {
        public User User { get; }
        public Product Product { get; }

        public InsufficientCreditsExceptions(User user, Product product)
            : base($"{user} tried purchasing {product} while only having a balance of {user.Balance}")
        {
            User = user;
            Product = product;
        }
    }
}
