namespace GestionProvedores.Exceptions
{
    public class NotFoundCustomerException : Exception
    {
        public NotFoundCustomerException()
        {
        }

        public NotFoundCustomerException(string message)
            : base(message)
        {
        }
    }
}
