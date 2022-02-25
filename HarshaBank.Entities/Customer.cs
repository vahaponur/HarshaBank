using HarshaBank.Entities.Contracts;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarshaBank.Entities
{
    public class Customer : ICustomer
    {
        #region Private Fields
        private Guid _customerID;
        private long _customerCode;
        private string _customerName;
        private string _address;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;
        #endregion

        #region Public Properties
        /// <summary>
        /// Unique identifier of the customer.
        /// </summary>
        public Guid CustomerID { get => _customerID; set => _customerID = value; }
        /// <summary>
        /// Second Customer identifier for Frontend.
        /// </summary>
        public long CustomerCode
        {
            get => _customerCode;
            set
            {
                if (value <= 0)
                    throw new CustomerException("Customer code should be greater than zero");

                _customerCode = value;

            }
        }
        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (value.Length > 50)
                    throw new CustomerException("Customer name should be less than 40 characters", new ArgumentOutOfRangeException());

                _customerName = value;

            }
        }
        /// <summary>
        /// Address of the customer.
        /// </summary>
        public string Address { get => _address; set => _address = value; }
        /// <summary>
        /// Landmark of the customer address.
        /// </summary>
        public string Landmark { get => _landmark; set => _landmark = value; }
        /// <summary>
        /// City of the customer address.
        /// </summary>
        public string City { get => _city; set => _city = value; }
        /// <summary>
        /// Country of the customer.
        /// </summary>
        public string Country { get => _country; set => _country = value; }
        /// <summary>
        /// 10 Digit customer mobile phone number
        /// </summary>
        public string Mobile
        {
            get => _mobile; 
            set
            {
                if (value.Length != 10)
                {
                    throw new CustomerException("Phone should be 10 digit number");
                }
                _mobile = value;
            }
        }
        #endregion

    }
}
