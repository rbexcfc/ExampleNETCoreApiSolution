using System;

namespace ClientService.Exceptions
{
    public class BlobExistsException : Exception
    {
        public BlobExistsException()
        {
        }

        public BlobExistsException(string message) : base(message)
        {
        }
    }
}
