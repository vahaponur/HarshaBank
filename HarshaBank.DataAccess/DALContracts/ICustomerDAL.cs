using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HarshaBank.Entities;
namespace HarshaBank.DataAccess.DALContracts
{
    /// <summary>
    /// Interface that represents customers data access layer.
    /// </summary>
    public interface ICustomerDAL
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
