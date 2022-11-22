namespace AspApplication.Domain.Entity
{
    public class NullContact : Contact
    {
        public NullContact() : base()
        {
            Id = 0;
            LastName = String.Empty;
            FirstName = String.Empty;
            MiddleName = String.Empty;
            PhoneNumber = String.Empty;
            Addres = String.Empty;
            Description = String.Empty;
        }
    }
}
