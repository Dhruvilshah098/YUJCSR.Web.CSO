namespace YUJCSR.Web.Project.Models
{
    public enum ApiMethod
    {
        ProjectCreate,
        ProjectUpdate
    }

    public class ProjectModel
	{
        public string? CSOID { get; set; }
        public string? ProjectID { get; set; }
        public string? refID { get; set; }
        public string? Title { get; set; }
        public string? areOfInterest { get; set; }
        public string? developmentGoal { get; set; }
        public string? projectDescription { get; set; }
        public string? Location { get; set; }
        public decimal? TotalBudget { get; set; }
        public decimal? DurationInMonths { get; set; }
        public string? expectedOutcome { get; set; }
        public string? amenities { get; set; }
        public string? experts { get; set; }
        public bool activeStatus { get; set; }
        public string? createdBy { get; set; }
        public string? modifiedBy { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? modifiedDate { get; set; }
    }

    public class  ProjectResultModel
    {
        public ProjectModel result { get; set; }
    }
}