using Shared;

namespace Services.Interfaces;

public interface IFacturation
{
    Task<IEnumerable<InvoiceModel>> getAllInvoiceAsync();
    Task<InvoiceModel?> getInvoiceByIdAsync(int id);
    Task<int> CreateAsync(InvoiceModel invoiceModel);
    Task<int> AddItemInvoiceByDetail(DetailModel model);
    Task<int> DeleteItemInvoice(int id);
}
