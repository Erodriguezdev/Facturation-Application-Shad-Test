using Data;
using Microsoft.EntityFrameworkCore;
using Models.Facturation;
using Services.Interfaces;
using Shared;

namespace Services.Repositories;

public class FacturationRepository : IFacturation
{
    private readonly ApplicationDbContext _context;

    public FacturationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InvoiceModel>> getAllInvoiceAsync()
    {
        var invoice = await _context.Invoices.AsNoTracking()
            .Select(x => new InvoiceModel
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.CustName,
                SubTotal = x.Total,
                TotalItbis = x.TotalItbis,
                Total = x.Total,
                InvoiceDetailModels = x.InvoiceDetails
                .Select(y => new InvoiceDetailModel
                {
                    Id = y.Id,
                    InvoiceId = y.InvoiceId,
                    Qty = y.Qty,
                    Price = y.Price,
                    SubTotal = y.SubTotal,
                    TotalItbis = y.TotalItbis,
                    Total = y.Total,
                }).ToList()

            }).ToListAsync();

        return invoice;
    }
    public async Task<InvoiceModel?> getInvoiceByIdAsync(int id)
    {
        var invoice = await _context.Invoices.AsNoTracking()
            .Where(x=> x.Id == id)
          .Select(x => new InvoiceModel
          {
              Id = x.Id,
              CustomerId = x.CustomerId,
              CustomerName = x.Customer.CustName,
              SubTotal = x.Total,
              TotalItbis = x.TotalItbis,
              Total = x.Total,
              InvoiceDetailModels = x.InvoiceDetails
              .Select(y => new InvoiceDetailModel
              {
                  Id = y.Id,
                  InvoiceId = y.InvoiceId,
                  Qty = y.Qty,
                  Price = y.Price,
                  SubTotal = y.SubTotal,
                  TotalItbis = y.TotalItbis,
                  Total = y.Total,
              }).ToList()

          }).FirstOrDefaultAsync();

        return invoice;
    }

    public async Task<int> AddItemInvoiceByDetail(DetailModel model)
    {
        if (model.Id == 0)
        {
            var InvoiceHeader = new Invoice
            {
                CustomerId = model.CustomerId,
                SubTotal = 0,
                 TotalItbis = 0,
                Total = 0
            };

           await _context.Invoices.AddAsync(InvoiceHeader);
            await _context.SaveChangesAsync();
            InvoiceDetail detail = new InvoiceDetail
            {
                InvoiceId = InvoiceHeader.Id,
                Qty = model.Qty,
                Price = model.price,
                SubTotal = model.Qty * model.price,
                TotalItbis = ( model.Qty * model.price ) * 0.18m,
                Total = ( model.Qty * model.price ) + ( model.Qty * model.price ) * 0.18m,

            };

            await _context.InvoiceDetails.AddAsync( detail );
             await _context.SaveChangesAsync();

            model.Id = InvoiceHeader.Id;         
        }
        else
        {
            InvoiceDetail detail = new InvoiceDetail
            {
                InvoiceId = model.Id,
                Qty = model.Qty,
                Price = model.price,
                SubTotal = model.Qty * model.price,
                TotalItbis = ( model.Qty * model.price ) * 0.18m,
                Total = ( model.Qty * model.price ) + ( model.Qty * model.price ) * 0.18m,

            };

            await _context.InvoiceDetails.AddAsync(detail);
            await _context.SaveChangesAsync();
        }


        var Invoice = await _context.Invoices.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
        var InvoiceDetail = await _context.InvoiceDetails.Where(x => x.InvoiceId == model.Id).ToListAsync();
        Invoice.SubTotal = InvoiceDetail.Select(x => x.SubTotal).Sum(); 
        Invoice.TotalItbis = InvoiceDetail.Select(x=> x.TotalItbis).Sum();
        Invoice.Total = InvoiceDetail.Select(x=> x.Total).Sum();

       await _context.SaveChangesAsync();

        return model.Id;
    }
    public async Task<int> CreateAsync(InvoiceModel invoiceModel)
    {
        var InvoiceHeader = new Invoice
        {
            CustomerId = invoiceModel.CustomerId,
            SubTotal = invoiceModel.InvoiceDetailModels.Select(x => x.SubTotal.Value).Sum(),
            TotalItbis = invoiceModel.InvoiceDetailModels.Select(x => x.SubTotal.Value * 0.18m).Sum(),
            Total = invoiceModel.InvoiceDetailModels.Select(x => x.SubTotal.Value).Sum() + invoiceModel.InvoiceDetailModels.Select(x => x.SubTotal.Value * 0.18m).Sum()
        };

        await _context.Invoices.AddAsync(InvoiceHeader);
        await _context.SaveChangesAsync();

        List<InvoiceDetail> detail = invoiceModel.InvoiceDetailModels.Select(x=> new InvoiceDetail
        {
            InvoiceId = InvoiceHeader.Id,
            Qty = x.Qty,
            Price = x.Price,
            SubTotal = x.SubTotal.Value,
            TotalItbis = x.SubTotal.Value * 0.18m,
            Total = x.SubTotal.Value + ( x.SubTotal.Value * 0.18m )

        }
            ).ToList();

        await _context.InvoiceDetails.AddRangeAsync( detail );
        return await _context.SaveChangesAsync();
    }

   public async Task<int> DeleteItemInvoice(int id)
    {
        var item = await _context.InvoiceDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (item != null)
        {
            _context.InvoiceDetails.Remove(item);
            await _context.SaveChangesAsync();
            return item.InvoiceId;
        }
        else
        { return 0; }
    }
}
