using Exam.Logic;

namespace Exam.Exception
{
    public class InsufficientCreditsExceptions : System.Exception
    {
        public User User { get; }
        public Product Product { get; }

        public InsufficientCreditsExceptions(User user, Product product)
        : base($"{user} tried purchasing {product.Name} while only having a balance of {user.Balance} and product price of {product.Price}")
        {
            User = user;
            Product = product;
        }
    }
}
