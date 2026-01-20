using expenseTrackerProject.DTOs;
namespace expenseTrackerProject.Interfaces
{
    public interface IExpenseService
    {
        List<ExpenseResponseDto> GetExpenses();
        ExpenseResponseDto GetExpense(int id);
        ExpenseResponseDto CreateExpense(CreateExpenseDto dto);
        ExpenseResponseDto UpdateExpense(UpdateExpenseDto dto, int id);
        bool DeleteExpense(int id);
    }
}
