using expenseTrackerProject.Interfaces;
using expenseTrackerProject.Models;

namespace expenseTrackerProject.Repositories
{
    public class ExpenseRepository: IExpenseRepository
    {
        private readonly List<Expense> expenses = new();

        public List<Expense> GetAll()
        {
            return expenses;
        }
        public Expense GetById(int id)
        {
            return expenses.FirstOrDefault(e => e.Id == id);
        }
        public Expense Add(Expense expense)
        {
            expense.Id = expenses.Count + 1;
            expense.Date = DateTime.Now;
            expenses.Add(expense);
            return expense;
        }
        public Expense Update(Expense expense)
        {
            var existing = GetById(expense.Id);
            if (existing == null) return null;

            existing.Title = expense.Title;
            existing.Amount = expense.Amount;
            return existing;
        }
        public bool Delete(int id)
        {
            var expense = GetById(id);
            if (expense == null) return false;

            expenses.Remove(expense);
            return true;
        }
    }
}