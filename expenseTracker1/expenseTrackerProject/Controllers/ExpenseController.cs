using Microsoft.AspNetCore.Mvc;
using expenseTrackerProject.DTOs;
using expenseTrackerProject.Interfaces;
namespace expenseTrackerProject.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetExpenses());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var expense = _service.GetExpense(id);
            if (expense == null) return NotFound();
            return Ok(expense);
        }

        [HttpPost]
        public IActionResult Create(CreateExpenseDto dto)
        {
            return Ok(_service.CreateExpense(dto));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateExpenseDto dto)
        {

            var result = _service.UpdateExpense(dto, id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.DeleteExpense(id)) return NotFound();
            return NoContent();
        }
    }
}
