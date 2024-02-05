using Newtonsoft.Json;
using System.Net.Http.Headers;
using YUJCSR.Web.CSO.Helper;
using YUJCSR.Web.Project.Models;

namespace YUJCSR.Web.CSO.BusinessManager
{
	public class ProjectManager
	{
		private string _baseurl;
		private IConfiguration _configuration;
		public ProjectManager(IConfiguration iConfig)
		{
			_configuration = iConfig;
			_baseurl =  _configuration.GetValue<string>("BaseUrl") + "/api/";
        }

		public List<ProjectModel> GetProjects()
		{
			List<ProjectModel> lstModel = new List<ProjectModel>();

			try
			{
				string dataResponse = CommonAPIHelper.GetApiData(_baseurl, "Project");

				if (!string.IsNullOrEmpty(dataResponse))
				{
					lstModel = JsonConvert.DeserializeObject<List<ProjectModel>>(dataResponse);
				}
				return lstModel;

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public List<MilestoneModel> GetMilestones(string projectId)
		{
			List<MilestoneModel> lstModel = new List<MilestoneModel>();

			try
			{
				string dataResponse = CommonAPIHelper.GetApiData(_baseurl, "Project/" + projectId + "/milestones");

				if (!string.IsNullOrEmpty(dataResponse))
				{
					var data = JsonConvert.DeserializeObject<ResultListMilestone>(dataResponse);
					lstModel = data != null ? data.result : new List<MilestoneModel>();
				}
				return lstModel;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public List<BudgetModel> GetBudgets(string projectId)
		{
			List<BudgetModel> lstModel = new List<BudgetModel>();

			try
			{
				string dataResponse = CommonAPIHelper.GetApiData(_baseurl, "Project/" + projectId + "/budgets");

				if (!string.IsNullOrEmpty(dataResponse))
				{
					var data = JsonConvert.DeserializeObject<ResultListBudget>(dataResponse);
					lstModel = data != null ? data.result : new List<BudgetModel>();
				}
				return lstModel;

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public bool CreateOrUpdateMilestone(ResultMilestone dataInputRequest)
		{
			ProjectResultModel model = new ProjectResultModel();

			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(_baseurl);
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					string apiMethod = string.Empty;
					if (string.IsNullOrEmpty(dataInputRequest.result.milestoneID))
					{
						apiMethod = "Project/" + dataInputRequest.result.projectID + "/Milestone";
						dataInputRequest.result.createdBy = "cso portal";
						dataInputRequest.result.activeStatus = true;
					}
					else
					{
						dataInputRequest.result.activeStatus = true;
						apiMethod = "Project/Milestone/" + dataInputRequest.result.milestoneID;
					}

					var postTask = client.PostAsJsonAsync<MilestoneModel>(apiMethod, dataInputRequest.result);

					postTask.Wait();
					var Res = postTask.Result;
					if (Res.IsSuccessStatusCode)
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				throw;
			}
			return false;
		}

		public bool CreateOrUpdateBudget(BudgetModel dataInputRequest)
		{
			ProjectResultModel model = new ProjectResultModel();

			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(_baseurl);
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					string apiMethod = string.Empty;

					if (string.IsNullOrEmpty(dataInputRequest.budgetID))
					{
						apiMethod = "Project/" + dataInputRequest.projectID + "/Budget";
						dataInputRequest.createdBy = "cso portal";
						dataInputRequest.activeStatus = true;
					}
					else
					{
						apiMethod = "Project/Budgets/" + dataInputRequest.budgetID;
						dataInputRequest.activeStatus = true;
					}

					var postTask = client.PostAsJsonAsync<BudgetModel>(apiMethod, dataInputRequest);
					postTask.Wait();
					var Res = postTask.Result;
					if (Res.IsSuccessStatusCode)
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				throw;
			}
			return false;
		}

		public bool CreateOrUpdateProject(ProjectModel dataInputRequest)
		{
			ProjectResultModel model = new ProjectResultModel();

			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(_baseurl);
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					string apiMethod = string.Empty;
					if (string.IsNullOrEmpty(dataInputRequest.ProjectID))
					{
						apiMethod = "Project";
						dataInputRequest.createdBy = "cso portal";
						dataInputRequest.activeStatus = true;
						dataInputRequest.refID = "2325565";//randomid


                    }
					else
					{
						dataInputRequest.activeStatus = true;
						apiMethod = "Project/" + dataInputRequest.ProjectID;
					}
					var postTask = client.PostAsJsonAsync<ProjectModel>(apiMethod, dataInputRequest);
					postTask.Wait();
					var Res = postTask.Result;
					if (Res.IsSuccessStatusCode)
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				throw;
			}
			return false;
		}

		public ProjectModel GetProjectById(string projectId)
		{
			ProjectModel model = new ProjectModel();

			try
			{
				string dataResponse = CommonAPIHelper.GetApiData(_baseurl, "Project/" + projectId);

				if (!string.IsNullOrEmpty(dataResponse))
				{
					var data = JsonConvert.DeserializeObject<ProjectResultModel>(dataResponse);
					if (data != null)
					{
						model = data.result;
					}
				}
				return model;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public ResultMilestone GetMilestoneById(string milestone)
		{
			ResultMilestone model = new ResultMilestone();

			try
			{
				string dataResponse = CommonAPIHelper.GetApiData(_baseurl, "Project/milestone/" + milestone);

				if (!string.IsNullOrEmpty(dataResponse))
				{
					var data = JsonConvert.DeserializeObject<ResultMilestone>(dataResponse);
					if (data != null && data.result != null)
					{
						model = data;
					}
				}
				return model;

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public BudgetModel GetBudgetById(string budgetId)
		{
			BudgetModel model = new BudgetModel();

			try
			{
				string dataResponse = CommonAPIHelper.GetApiData(_baseurl, "Project/Budgets/" + budgetId);

				if (!string.IsNullOrEmpty(dataResponse))
				{
					var data = JsonConvert.DeserializeObject<ResultBudget>(dataResponse);
					if (data != null && data.result != null)
					{
						model = data.result;
					}
				}
				return model;

			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
