using ProiectColectiv.Data;
using ProiectColectiv.Data.Repositories;

namespace ProiectColectiv.AppDbContext
{
    public class BillRepository : IRepository<Bill, BillPostDTO>
    {
        private readonly ApplicationDbContext _context;

        public BillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Bill GetById(int id)
        {
            return _context.Bills.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Bill> GetAll(string userName)
        {
            return _context.Bills.Where(x => x.UserName == userName);
        }

        public void Add(BillPostDTO bill)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == bill.userEmail);

            var billToAdd = new Bill
            {
                UserId = new Guid(user.Id),
                CarId = new Guid(bill.carId),
                DateOfIssue = bill.DateOfIssue,
                BillAmount = bill.BillAmount,
                Description = bill.Description
            };

            _context.Bills.Add(billToAdd);
            _context.SaveChanges();
        }

        public void Update(Bill bill)
        {
            _context.Bills.Update(bill);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var billToRemove = _context.Bills.FirstOrDefault(b => b.Id == id);
            if (billToRemove != null)
            {
                _context.Bills.Remove(billToRemove);
                _context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}