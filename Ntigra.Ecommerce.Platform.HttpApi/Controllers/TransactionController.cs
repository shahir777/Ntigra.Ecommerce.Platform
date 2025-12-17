using Microsoft.AspNetCore.Mvc;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("v1/app/transaction")]
    public class TransactionController : ControllerBase
    {
        //private readonly ITransactionService _transactionService;

        //public TransactionController(ITransactionService transactionService)
        //{
        //    _transactionService = transactionService;
        //}

        /// <summary>
        /// Get transaction details by transaction UID
        /// </summary>
        /// <param name="transactionUid"></param>
        /// <returns></returns>
        [HttpGet("{transactionUid}")]
        public async Task<IActionResult> GetTransaction(string transactionUid)
        {
            if (string.IsNullOrWhiteSpace(transactionUid))
                return BadRequest("transactionUid is required");

            //var result = await _transactionService.GetTransactionByUidAsync(transactionUid);

            //if (result == null)
            //    return NotFound("Transaction not found");

            return Ok(new
            {
                status = true,
                responseCode = "000",
                responseMessage = "Operation successful",
                data = "result"
            });
        }
    }
}
