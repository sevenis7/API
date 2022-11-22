namespace AspApplication.Domain.Entity
{
    public class NullUser : User
    {
        public NullUser() : base()
        {
            UserName = "Empty user";
        }
    }
}
