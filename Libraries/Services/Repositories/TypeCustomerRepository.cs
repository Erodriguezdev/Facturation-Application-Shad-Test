
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Facturation;
using Services.Interfaces;
using Shared;

namespace Services.Repositories
{
    public class TypeCustomerRepository : ItypeCustomer
    {
        private readonly ApplicationDbContext _context;

        public TypeCustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TypeCustomerModel>> GetTypeCustomerAsync(string typecustomer)
        {
            if (string.IsNullOrEmpty(typecustomer))
                typecustomer = "";

            IEnumerable<TypeCustomerModel> TYPECUSTOMER = await _context.CustomerTypes
                .AsNoTracking()
                .Select(x => new TypeCustomerModel
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .ToListAsync();

            return TYPECUSTOMER;
        }
        public async Task<TypeCustomerModel> GetByIdAsync(int Id)
        {
            var customerTypes = await _context.CustomerTypes
                .Select(x => new TypeCustomerModel
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .FirstOrDefaultAsync().ConfigureAwait(false);


            return customerTypes;

        }
        public async Task<int> CreateTypeCustomerAsync(TypeCustomerModel Typecustomer)
        {
            if (string.IsNullOrEmpty(Typecustomer.Description))
                return 0;
            CustomerType customerType = new CustomerType
            {
                Description = Typecustomer.Description
            };
           await _context.AddAsync(customerType);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateTypeCustomerAsync(TypeCustomerModel Typecustomer)
        {
            var customerType = await _context.CustomerTypes.Where(x=> x.Id == Typecustomer.Id).FirstOrDefaultAsync().ConfigureAwait(false);
            if(customerType != null)
            {
                customerType.Description = Typecustomer.Description;
                return await _context.SaveChangesAsync();
            }
            else
            { return 0; }
        }
        //Task<bool> DeleteTypeCustomerAsync(int Id);
    }
}
