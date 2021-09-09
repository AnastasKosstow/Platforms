using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
