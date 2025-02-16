using Microsoft.AspNetCore.Mvc;
using simple_ledger_C_.Models;

namespace simple_ledger_C_.Controllers
{
    [ApiController]
    [Route("api/ledger")]
    public class LedgerController : ControllerBase
    {
        private readonly ILedgerRepository _ledgerRepository;

        public LedgerController(ILedgerRepository ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }

        /// <summary>
        /// Usage:
        /// Positive amount => deposit, negative amount => withdrawal
        /// 
        /// curl -X POST "http://localhost:5000/api/ledger/transaction" -H "amount: -50" -H "userId: user1"
        /// </summary>
        [HttpPost("transaction")]
        public IActionResult RecordTransaction(
            [FromHeader] decimal amount,
            [FromHeader] string userId)
        {
            _ledgerRepository.RecordTransaction(amount, userId);
            return Ok("Transaction recorded successfully");
        }

        [HttpGet("balance")]
        public IActionResult GetBalance([FromHeader] string userId)
        {
            return Ok(_ledgerRepository.GetBalance(userId));
        }

        [HttpGet("transactions")]
        public IActionResult GetTransactions([FromHeader] string userId)
        {
            return Ok(_ledgerRepository.GetTransactions(userId));
        }
    }
}
