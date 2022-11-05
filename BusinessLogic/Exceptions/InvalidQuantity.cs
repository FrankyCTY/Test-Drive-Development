namespace BusinessLogic.Exceptions
{
    public class InvalidQuantity : Exception
    {
        public InvalidQuantity(int invalidQuantity)
            : base($"{invalidQuantity} is an invalid quantity.")
        {

        }
    }
}
