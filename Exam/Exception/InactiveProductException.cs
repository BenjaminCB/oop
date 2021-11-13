using Exam.Logic;

namespace Exam.Exception
{
    public class InactiveProductException : System.Exception
    {
        public InactiveProductException(User user, Product product)
            : base($"{user} tride purchasing {product} which is inactive") {}
    }
}
