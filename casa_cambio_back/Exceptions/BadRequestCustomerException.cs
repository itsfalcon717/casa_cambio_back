namespace GestionProvedores.Exceptions
{
    public class BadRequestCustomerException : Exception
    {
        public BadRequestCustomerException()
        {
        }

        public BadRequestCustomerException(string message)
            : base(message)
        {
        }
    }
}
