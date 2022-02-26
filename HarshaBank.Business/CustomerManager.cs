using HarshaBank.Business.BALContracts;
using HarshaBank.Configuration;
using HarshaBank.DataAccess;
using HarshaBank.DataAccess.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarshaBank.Business
{
    /// <summary>
    /// Represent Customer Business Logic
    /// </summary>
    public class CustomerManager : ICustomerService
    {
        #region Private Fields
        private ICustomerDAL _customerDAL;

        #endregion

        #region Constructors
        public CustomerManager()
        {
            _customerDAL = new CustomerDAL();
        }
        #endregion

        #region Private Properties
        private ICustomerDAL CustomerDAL
        {
            get => this._customerDAL;
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Returns all existing Customers
        /// </summary>
        /// <returns>All Customers List</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                //Invoke DAL
                return CustomerDAL.GetCustomers();
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get Customer by Condition
        /// </summary>
        /// <param name="condition">Lambda Expression Condition</param>
        /// <returns>The list of customers that match with condition</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> condition)
        {
            try
            {
                //Invoke DAL
                return CustomerDAL.GetCustomersByCondition(condition);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Adds a new customer to the existing customer list.
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns CustomerID if added successfully</returns>
       public Guid AddCustomer(Customer customer)
        {
            try
            {

                //Generate Customer No
                customer.CustomerCode = NextCustomerCode();


                //Invoke DAL
                return CustomerDAL.AddCustomer(customer);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates the given customer
        /// </summary>
        /// <param name="customer">Customer to update</param>
        /// <returns>Returns true, if customer updated successfully, false otherwise</returns>
       public bool UpdateCustomer(Customer customer)
        {
            try
            {
                return CustomerDAL.UpdateCustomer(customer);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Deletes the given customer
        /// </summary>
        /// <param name="customerID">Customer to delete</param>
        /// <returns>Returns true, if customer deleted successfully, false otherwise</returns>
       public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                return CustomerDAL.DeleteCustomer(customerID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region PrivateMethods
        private long NextCustomerCode()
        {
            //Increase Base Customer No
            ++Settings.BaseCustomerNo;
            //Get Customer List
            var customers = GetCustomers();
            //Check if list empty, if not biggest customer no + 1 will be assigned.
            return customers.Count > 0 ? customers.Max(c => c.CustomerCode) + 1 : Settings.BaseCustomerNo;
        }
        #endregion

    }
}
