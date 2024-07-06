using System.Collections.Generic;
using System.Linq;
using CustomerAccessControl.Data;
using CustomerAccessControl.Models;

namespace CustomerAccessControl.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }

        public Customer RegisterCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void UpdateCustomerAuthorization(int id, bool isAuthorized)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                customer.IsAuthorized = isAuthorized;
                _context.SaveChanges();
            }
        }

        public List<Customer> GetCustomersByEntryDateRange(int centerId, DateTime startDate, DateTime endDate)
        {
            return _context.Entries
                .Where(e => e.CenterId == centerId && e.EntryDate >= startDate && e.EntryDate <= endDate)
                .Select(e => e.Customer)
                .ToList();
        }

        public List<Customer> GetTop10CustomersByEntries(int centerId, DateTime month)
        {
            var startDate = new DateTime(month.Year, month.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return _context.Entries
                .Where(e => e.CenterId == centerId && e.EntryDate >= startDate && e.EntryDate <= endDate)
                .GroupBy(e => e.CustomerId)
                .OrderByDescending(g => g.Count())
                .Take(10)
                .Select(g => g.First().Customer)
                .ToList();
        }

        public List<Customer> GetCustomersNotReturnedAfterFirstVisit(int centerId)
        {
            var customerIds = _context.Entries
                .Where(e => e.CenterId == centerId)
                .GroupBy(e => e.CustomerId)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .ToList();

            return _context.Customers
                .Where(c => customerIds.Contains(c.Id))
                .ToList();
        }

        public List<Customer> GetCustomersNotAuthorized(int centerId)
        {
            return _context.Customers
                .Where(c => !c.IsAuthorized)
                .ToList();
        }

        public List<Customer> GetTopCustomersByZone(int centerId, DateTime month)
        {
            var startDate = new DateTime(month.Year, month.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return _context.Entries
                .Where(e => e.CenterId == centerId && e.EntryDate >= startDate && e.EntryDate <= endDate)
                .GroupBy(e => new { e.CustomerId, e.Customer.Zone })
                .OrderByDescending(g => g.Count())
                .Select(g => g.First().Customer)
                .ToList();
        }
    }
}

