using expenseTrackerProject.Models;
namespace expenseTrackerProject.Interfaces
{
    public interface IExpenseRepository
    {
        List<Expense> GetAll();
        Expense GetById(int id);
        Expense Add(Expense expense);
        Expense Update(Expense expense);
        bool Delete(int id);
       
    }
}
