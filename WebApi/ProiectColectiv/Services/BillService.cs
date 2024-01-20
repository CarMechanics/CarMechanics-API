using ProiectColectiv.Data;
using ProiectColectiv.Data.Repositories;

namespace ProiectColectiv.Services;

public class BillService : IBillService
{
    private readonly IRepository<Bill, BillPostDTO> _billRepository;
    public BillService(IRepository<Bill, BillPostDTO> billRepository)
    {
        _billRepository = billRepository ?? throw new ArgumentNullException(nameof(billRepository));
    }
    public Bill GetBillById(int billId)
    {
        return _billRepository.GetById(billId);
    }
    public IEnumerable<Bill> GetAllBills(string userEmail)
    {
        return _billRepository.GetAll(userEmail);
    }
    public void AddBill(BillPostDTO bill)
    {
        _billRepository.Add(bill);
    }
    public void UpdateBill(BillPostDTO bill, int billId)
    {
        var existingBill = _billRepository.GetById(billId);
        if (existingBill == null)
        {
            throw new ArgumentException($"Bill with ID {billId} not found.");
        }
        existingBill.Description = bill.Description;
        existingBill.DateOfIssue = bill.DateOfIssue;
        existingBill.BillAmount = bill.BillAmount;
    }
    public void DeleteBill(int billId)
    {
        _billRepository.Delete(billId);
    }
}