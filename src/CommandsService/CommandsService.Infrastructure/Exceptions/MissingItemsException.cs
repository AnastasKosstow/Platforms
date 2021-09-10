
namespace CommandsService.Infrastructure.Exceptions
{
    public class MissingItemsException : BaseException
    {
        public MissingItemsException()
        {
        }

        public MissingItemsException(string error)
            =>
            Error = error;
    }
}
