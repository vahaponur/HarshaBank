using HarshaBank.Entities;
using System;
using System.Collections.Generic;


namespace HarshaBank.Business.BALContracts
{
    /// <summary>
    /// Interface for Customer Business Logic
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Returns all existing Customers
        /// </summary>
        /// <returns>All Customers List</returns>
        List<Customer> GetCustomers();
        /// <summary>
        /// Get Customer by Condition
        /// </summary>
        /// <param name="condition">Lambda Expression Condition</param>
        /// <returns>The list of customers that match with condition</returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> condition);
        /// <summary>
        /// Adds a new customer to the existing customer list.
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns CustomerID if added successfully</returns>
        Guid AddCustomer(Customer customer);

        /// <summary>
        /// Updates the given customer
        /// </summary>
        /// <param name="customer">Customer to update</param>
        /// <returns>Returns true, if customer updated successfully, false otherwise</returns>
        bool UpdateCustomer(Customer customer);
        /// <summary>
        /// Deletes the given customer
        /// </summary>
        /// <param name="customerID">Customer to delete</param>
        /// <returns>Returns true, if customer deleted successfully, false otherwise</returns>
        bool DeleteCustomer(Guid customerID);
    }
}
