using System;


namespace HarshaBank.Exceptions
{
    /// <summary>
    /// Exception class that represents validation errors raised in Customer class
    /// </summary>
    public class CustomerException:ApplicationException
    {
      

        /// <summary>
        /// Ctor that initializes exception message
        /// </summary>
        /// <param name="message">Exception Message</param>
        public CustomerException(string message):base(message)
        {

        }

        /// <summary>
        /// Ctor that initializes exception message and inner exception
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="innerException">Inner exception</param>
        public CustomerException(string message,Exception innerException):base(message,innerException)
        {

        }
    }
}
