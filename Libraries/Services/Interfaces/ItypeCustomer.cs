using Shared;

namespace Services.Interfaces;

public interface ItypeCustomer
{
    Task<IEnumerable<TypeCustomerModel>> GetTypeCustomerAsync(string typecustomer);
    Task<TypeCustomerModel> GetByIdAsync(int Id);
    Task<int> CreateTypeCustomerAsync(TypeCustomerModel Typecustomer);
    Task<int> UpdateTypeCustomerAsync (TypeCustomerModel Typecustomer);
}
