using expenseTrackerProject.DTOs;
using expenseTrackerProject.Interfaces;
using expenseTrackerProject.Models;

namespace expenseTrackerProject.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repo;

        public ExpenseService(IExpenseRepository repo)
        {
            _repo = repo;
        }

        public List<ExpenseResponseDto> GetExpenses()
        {
            return _repo.GetAll()
                .Select(e => new ExpenseResponseDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Amount = e.Amount
                })
                .ToList();
        }

        public ExpenseResponseDto GetExpense(int id)
        {
            var expense = _repo.GetById(id);
            if (expense == null) return null;

            return new ExpenseResponseDto
            {
                Id = expense.Id,
                Title = expense.Title,
                Amount = expense.Amount
            };
        }

        public ExpenseResponseDto CreateExpense(CreateExpenseDto dto)
        {
            var expense = new Expense
            {
                Title = dto.Title,
                Amount = dto.Amount
            };

            var saved = _repo.Add(expense);

            return new ExpenseResponseDto
            {
                Id = saved.Id,
                Title = saved.Title,
                Amount = saved.Amount
            };
        }

        public ExpenseResponseDto UpdateExpense(UpdateExpenseDto dto, int id)
        {
            var expense = new Expense
            {
                Id = id,
                Title = dto.Title,
                Amount = dto.Amount
            };

            var updated = _repo.Update(expense);
            if (updated == null) return null;

            return new ExpenseResponseDto
            {
                Id = updated.Id,
                Title = updated.Title,
                Amount = updated.Amount
            };
        }

        public bool DeleteExpense(int id)
        {
            return _repo.Delete(id);
        }
    }
}
