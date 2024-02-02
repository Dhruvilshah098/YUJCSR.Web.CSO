namespace YUJCSR.Web.Project.Models
{
	public class ResultListMilestone
	{
		public List<MilestoneModel> result { get; set; }
        public string projectId { get; set; }
	}

	public class ResultMilestone
	{
		public MilestoneModel result { get; set; }
		public string message { get; set; }
		public string status { get; set; }
	}

	public class MilestoneModel
    {
        public string? milestoneID { get; set; }
        public string? milestoneName { get; set; }
        public string? description { get; set; }
        public string? projectID { get; set; }
        public bool activeStatus { get; set; }
        public string? createdBy { get; set; }
        public string? modifiedBy { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? modifiedDate { get; set; }
    }

}
