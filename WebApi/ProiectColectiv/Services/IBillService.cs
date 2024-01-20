using ProiectColectiv.Data;

namespace ProiectColectiv.Services
{
    public interface IBillService
    {
        Bill GetBillById(int billId);
        IEnumerable<Bill> GetAllBills(string userEmail);
        void AddBill(BillPostDTO bill);
        void UpdateBill(BillPostDTO bill, int billId);
        void DeleteBill(int BillId);
    }
}