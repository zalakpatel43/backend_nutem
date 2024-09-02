namespace Domain.ViewModels
{
    public class PrePostQuestionList
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; } // Assuming you'll want to display the product name instead of just the ID
        public int Type { get; set; }  // 1 for Pre-check, 2 for Post-check
        public string Question { get; set; }
        public bool? IsActive { get; set; }
    }
}
