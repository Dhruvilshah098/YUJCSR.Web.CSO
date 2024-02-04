namespace YUJCSR.Web.CSO.Models
{
    public class UNSDGModel
    {
        public string unsdgid { get; set; }
        public string unsdgName { get; set; }
        public string unsdgNumber { get; set; }
        public string photoPath { get; set; }
        public string activeStatus { get; set; }
        public string createdBy { get; set; }
        public string modifiedBy { get; set; }
        public string createdDate { get; set; }
        public string modifiedDate { get; set; }
    }

    public class UNSDGResultModel
    {
        public List<UNSDGModel> result { get; set; }
    }
}
