namespace expenseTrackerProject.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Title { get; set; }
         public DateTime date { get; set; }
        public DateTime Date { get; internal set; }
    }
}
