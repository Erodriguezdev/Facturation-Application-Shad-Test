
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Facturation;
using Services.Interfaces;
using Shared;
using System.Security.Cryptography.X509Certificates;

namespace Services.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerModel>> getCustomersAsync(string Customer)
        {
            if (string.IsNullOrEmpty(Customer))
                Customer = "";


            IEnumerable<CustomerModel> customers = await _context.Customers.AsNoTracking()
                .Where(x => x.CustName.ToLower().Contains(Customer))
                .Select(x => new CustomerModel
                {
                    Id = x.Id,
                    Name = x.CustName,
                    Address = x.Address,
                    Status = x.Status,
                    TypeCustomerId = x.CustomerTypeId,
                    TypeCustomer = x.CustomerType.Description,

                }).ToListAsync();

            return customers;

        }
        public async Task<CustomerModel?> getCustomerByIdAsync(int CustomerId)
        {
            CustomerModel? customer = await _context.Customers.AsNoTracking()
              .Select(x => new CustomerModel
              {
                  Id = x.Id,
                  Name = x.CustName,
                  Address = x.Address,
                  Status = x.Status,
                  TypeCustomerId = x.CustomerTypeId,
                  TypeCustomer = x.CustomerType.Description,

              }).FirstOrDefaultAsync();

            return customer;
        }

        public async Task<int> CreateCustomer(CustomerModel customer)
        {   
            Customers Customer = new Customers
            {
                CustName = customer.Name,
                Address = customer.Address,
                Status = customer.Status,
                CustomerTypeId = customer.TypeCustomerId
            };

            await _context.Customers.AddAsync(Customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCustomer(CustomerModel customer)
        {
            var customers = await _context.Customers
               .Where(x => x.Id == customer.Id)
               .FirstOrDefaultAsync();

            if (customers == null)
                return 0;
            
            customers.CustName = customer.Name;
            customers.Address = customer.Address;
            customers.Status = customer.Status;
            customers.CustomerTypeId = customer.TypeCustomerId;

            return await _context.SaveChangesAsync();

        }
    }
}
