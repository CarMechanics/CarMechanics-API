using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Data;
using ProiectColectiv.Services;

namespace ProiectColectiv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private readonly IBillService _billService;

        public BillController(ILogger<BillController> logger, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
        }

        [HttpPost]
        public ActionResult Post(BillPostDTO bill)
        {
            _billService.AddBill(bill);

            return new JsonResult(bill);
        }

        [HttpGet]
        public IEnumerable<Bill> Get(string userEmail)
        {
            var bill = _billService.GetAllBills(userEmail);

            return bill;
        }

        [HttpGet("{billId}")]
        public Bill GetReviewById(int billId)
        {
            return _billService.GetBillById(billId);
        }

        [HttpPut("{billId}")]
        public ActionResult Update([FromBody] BillPostDTO bill, int billId)
        {
            _billService.UpdateBill(bill, billId);

            return new JsonResult(true);
        }
    }
}
