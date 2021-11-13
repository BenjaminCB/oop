namespace Exam.Exception
{
    public class ProductIdNotFoundException : System.Exception
    {
        public ProductIdNotFoundException(int id)
            : base($"No product with {id} found in the system") {}
    }
}
