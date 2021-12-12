namespace Exam.Exception
{
    public class ProductIdNotFoundException : System.Exception
    {
        public int Id { get; }
        public ProductIdNotFoundException(int id)
            : base($"No product with {id} found in the system")
        {
            Id = id;
        }
    }
}
