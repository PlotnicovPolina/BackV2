using System;

namespace BackV2.BackV2Exception
{
    public class BaseException : Exception
    {
        public BaseException(string message)
            : base(message)
        {
        }
    }
}
