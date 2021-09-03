
namespace PlatformService.Infrastructure.Exceptions
{
    public class InvalidRequestModelException : BaseException
    {
        public InvalidRequestModelException()
        {
        }

        public InvalidRequestModelException(string error) 
            => 
            Error = error;
    }
}
