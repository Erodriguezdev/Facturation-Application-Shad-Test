using Shared;

namespace Services.Interfaces;

public interface ICustomer
{
    Task<IEnumerable<CustomerModel>> getCustomersAsync(string Customer);
    Task<CustomerModel?> getCustomerByIdAsync(int CustomerId);
    Task<int> CreateCustomer (CustomerModel customer);
    Task<int> UpdateCustomer(CustomerModel customer);

}
