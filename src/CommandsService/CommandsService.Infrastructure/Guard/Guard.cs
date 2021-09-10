using CommandsService.Infrastructure.Exceptions;

namespace CommandsService.Infrastructure.Validation
{
    public static class Guard
    {
        public static void AgainstInvalidModel<TValue, TException>(TValue value)
            where TException : BaseException, new()
        {
            if (value is not null)
                return;

            ThrowException<TException>($"Invalid model!");
        }

        public static void AgainstNullOrEmpty<TValue, TException>(TValue value)
            where TException : BaseException, new()
        {
            if (value is not null)
                return;

            ThrowException<TException>($"Null or Empty!");
        }


        private static void ThrowException<TException>(string message)
            where TException : BaseException, new()
        {
            var exception = new TException
            {
                Error = message
            };

            throw exception;
        }
    }
}
