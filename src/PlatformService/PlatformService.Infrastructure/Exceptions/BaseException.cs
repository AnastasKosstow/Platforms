using System;

namespace PlatformService.Infrastructure.Exceptions
{
    public abstract class BaseException : Exception
    {
        private string error;

        public string Error
        {
            get => error ?? base.Message;
            set => error = value;
        }
    }
}
