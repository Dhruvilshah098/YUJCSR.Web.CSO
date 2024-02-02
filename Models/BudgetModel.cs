namespace YUJCSR.Web.Project.Models
{
	public class ResultListBudget
    {
        public List<BudgetModel> result { get; set; }
        public string projectId { get; set; }
    }

	public class ResultBudget
	{
		public BudgetModel result { get; set; }
	}

	public class BudgetModel
    {
        public string? budgetID { get; set; }
        public string? projectID { get; set; }
        public string? milestone { get; set; }
        public string? description { get; set; }
        public decimal amount { get; set; }
        public bool activeStatus { get; set; }
        public string? createdBy { get; set; }
        public string? modifiedBy { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? modifiedDate { get; set; }
    }
}
