using Stregsystem.Exception;

namespace Stregsystem
{
    public class BuyTransaction : Transaction
    {
        public Product Product { get; }

        public BuyTransaction(User user, Product product)
        : base(user, product.Price)
        {
             Product = product;
        }

        public override void Execute()
        {
            if (!Product.Active) throw new InactiveProductException(User, Product);
            if (User.Balance < Product.Price && !Product.CanBeBoughtOnCredit)
                throw new InsufficientCreditsExceptions(User, Product);

            User.Balance -= Amount;
        }

        public override string ToString() =>
            $"{this.GetType().Name} ({Id}) at {Date}: {User} purchased {Product}";
    }
}
