using System.Net.Http.Headers;
using YUJCSR.Web.CSO.Models;

namespace YUJCSR.Web.CSO.BusinessManager
{
    public class CSOManager
    {
        private string _baseurl;
        private IConfiguration _configuration;
        public CSOManager(IConfiguration iConfig)
        {
            _configuration = iConfig;
            _baseurl = _configuration.GetValue<string>("BaseUrl");
        }

        public bool OnBoardCSO(CSOProfileModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    model.ActiveStatus = true;
                    model.CreatedBy = "cso portal";
                    model.ApprovalStatus = "pending";
                    model.Address = "-";
                    model.OrgType = "cso";
                    
                    client.BaseAddress = new Uri(_baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var postTask  = client.PostAsJsonAsync<CSOProfileModel>("cso/onboard", model);
                    postTask.Wait();
                    var Res = postTask.Result;
                    if (Res.IsSuccessStatusCode)
                    {
                        return true ;
                    }


                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool LoginCheck(LoginModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(_baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var postTask = client.PostAsJsonAsync<LoginModel>("cso/login", model);
                    postTask.Wait();
                    var Res = postTask.Result;
                    if (Res.IsSuccessStatusCode)
                    {
                        return true;
                    }


                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
