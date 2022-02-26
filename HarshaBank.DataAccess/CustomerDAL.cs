using HarshaBank.DataAccess.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarshaBank.DataAccess
{
    /// <summary>
    /// Represents DAL for bank customers.
    /// </summary>
    public class CustomerDAL : ICustomerDAL
    {
        #region Private Fields
        private List<Customer> _customers;
        #endregion

        #region PrivateProperties
        /// <summary>
        /// Represents source customer collection.
        /// </summary>
        private List<Customer> Customers { get => _customers; set => _customers=value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor.Initializes source customer collection.
        /// </summary>
        public CustomerDAL()
        {
            Customers = new List<Customer>();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a new customer to the existing customer list.
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns CustomerID if added successfully</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {

                customer.CustomerID = Guid.NewGuid();
                Customers.Add(customer);
                return customer.CustomerID;
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
        /// Deletes the given customer
        /// </summary>
        /// <param name="customerID">Customer to delete</param>
        /// <returns>Returns true, if customer deleted successfully, false otherwise</returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                return Customers.RemoveAll(c => c.CustomerID == customerID) >= 1;

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
        /// Returns a deep copy of all customers source collection.
        /// </summary>
        /// <returns>All Customers List</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                List<Customer> customers = new List<Customer>();

                //Deep copy all customers from source collection
                Customers.ForEach(item => customers.Add(item.Clone() as Customer));
                return customers;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {

                throw ;
            }
   
        }

        /// <summary>
        /// Returns list of customers that are matching with specified condition
        /// </summary>
        /// <param name="condition">Lambda expression (Condition)</param>
        /// <returns>List of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> condition)
        {
            try
            {
                List<Customer> customers = new List<Customer>();

                //Filter with predicate
                List<Customer> filtered = Customers.FindAll(condition);
                //Make a deep copy of filtered collection.
                filtered.ForEach(item => customers.Add(item.Clone() as Customer));

                return customers;
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
                var customerToUpdate = Customers.Find(c => c.CustomerID == customer.CustomerID);

                //If customer not found return false
                if (customerToUpdate == null)
                {
                    return false;
                }

                //Map parameter object to already existing one if the property is not default or null
                customerToUpdate.CustomerCode = customer.CustomerCode != default(long) ? customer.CustomerCode : customerToUpdate.CustomerCode;
                customerToUpdate.CustomerName = customer.CustomerName != default(string) ? customer.CustomerName : customerToUpdate.CustomerName;
                customerToUpdate.Address = customer.Address != default(string) ? customer.Address : customerToUpdate.Address;
                customerToUpdate.Landmark = customer.Landmark != default(string) ? customer.Landmark : customerToUpdate.Landmark;
                customerToUpdate.City = customer.City != default(string) ? customer.City : customerToUpdate.City;
                customerToUpdate.Country = customer.Country != default(string) ? customer.Country : customerToUpdate.Country;
                customerToUpdate.Mobile = customer.Mobile != default(string) ? customer.Mobile : customerToUpdate.Mobile;

                return true; //Indicates customer is updated
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
        #endregion
    }
}
