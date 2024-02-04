using Newtonsoft.Json;
using System.Net.Http.Headers;
using YUJCSR.Web.Portal.Models;
using YUJCSR.Web.Project.Models;

namespace YUJCSR.Web.Portal.Business
{
    public class ProjectManager
    {
        public  List<ProjectModel> GetProjects()
        {
            //APIResponse list = new APIResponse();
            List<ProjectModel> list = new List<ProjectModel>();
            try
            {
                //string Baseurl = "https://yujcsrapi.brainspark.in/";
                //using (var client = new HttpClient())
                //{
                //    //Passing service base url
                //    client.BaseAddress = new Uri(Baseurl);
                //    client.DefaultRequestHeaders.Clear();
                //    //Define request data format
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                //    HttpResponseMessage Res =  client.GetAsync("api/Project/projects").Result;
                //    //Checking the response is successful or not which is sent using HttpClient
                //    if (Res.IsSuccessStatusCode)
                //    {
                //        //Storing the response details recieved from web api
                //        var EmpResponse = await Res.Content.ReadAsStringAsync();
                //        //Deserializing the response recieved from web api and storing into the Employee list
                //       var data  = JsonConvert.DeserializeObject<APIResponse>(EmpResponse);
                //    }
                //}



                list.Add(new ProjectModel()
                {
                    projectID= "1",
                    Title = "Education",
                    DurationInMonths = 48,
                    TotalBudget = 4500000,
                    Location = "Goa"

                });
                list.Add(new ProjectModel()
                {
                    ProjectID = "2",
                    Title = "Education",
                    DurationInMonths = 48,
                    TotalBudget = 4500000,
                    Location = "Goa"

                });
                list.Add(new ProjectModel()
                {
                    ProjectID = "3",
                    Title = "Education",
                    DurationInMonths = 48,
                    TotalBudget = 4500000,
                    Location = "Goa"

                });
                list.Add(new ProjectModel()
                {
                    ProjectID = "4",
                    Title = "Education",
                    DurationInMonths = 48,
                    TotalBudget = 4500000,
                    Location = "Goa"

                });
                list.Add(new ProjectModel()
                {
                    ProjectID = "5",
                    Title = "Education",
                    DurationInMonths = 48,
                    TotalBudget = 4500000,
                    Location = "Goa"

                });
                list.Add(new ProjectModel()
                {
                    ProjectID = "6",
                    Title = "Education",
                    DurationInMonths = 48,
                    TotalBudget = 4500000,
                    Location = "Goa"

                });
                list.Add(new ProjectModel()
                {

                    Title = "Education",
                    DurationInMonths = 48,
                    TotalBudget = 4500000,
                    Location = "Goa"

                });
                list.Add(new ProjectModel()
                {

                    Title = "Education",
                    DurationInMonths = 48,
                    TotalBudget = 4500000,
                    Location = "Goa"

                });

            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
    }
}
