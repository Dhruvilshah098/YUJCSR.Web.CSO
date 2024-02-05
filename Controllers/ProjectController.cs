using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using YUJCSR.Web.CSO.BusinessManager;
using YUJCSR.Web.Project.Models;

namespace YUJCSR.Web.CSO.Controllers
{
	public class ProjectController : Controller
	{
		IConfiguration _config;
		public ProjectController(IConfiguration iConfig)
		{
			_config = iConfig;
		}


		public IActionResult Create()
		{
			return View("Save", new ProjectModel());
		}

		public IActionResult CreateMilestone(string projectId)
		{
			ResultMilestone objResultMilestone = new ResultMilestone();
			objResultMilestone.result = new MilestoneModel();
			objResultMilestone.result.projectID = projectId;
			return View("Milestone/Save", objResultMilestone);
		}

		public IActionResult EditMilestone(string milestoneId)
		{
			ProjectManager manager = new ProjectManager(_config);
			var data = manager.GetMilestoneById(milestoneId);
			return View("Milestone/Save", data);
		}

		public IActionResult EditBudget(string budgetId)
		{
			ProjectManager manager = new ProjectManager(_config);

			var data = manager.GetBudgetById(budgetId);
			return View("Budget/Save", data);
		}

		public IActionResult CreateBudget(string projectId)
		{
			return View("Budget/Save", new BudgetModel { projectID = projectId  });
		}

		[HttpPost]
		public IActionResult SaveProject(ProjectModel dataModel)
		{
			ProjectManager manager = new ProjectManager(_config);

			var data = manager.CreateOrUpdateProject(dataModel);

			if (data)
			{
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Error = "Error occured. Please contact support";
                return View("Save", dataModel);
            }
		}

		[HttpPost]
		public IActionResult SaveBudget(BudgetModel dataModel)
		{
			ProjectManager manager = new ProjectManager(_config);

			var data = manager.CreateOrUpdateBudget(dataModel);

			return RedirectToAction("Budget", new { projectId = dataModel.projectID });
		}

		[HttpPost]
		public IActionResult SaveMilestone(ResultMilestone dataModel)
		{
			ProjectManager manager = new ProjectManager(_config);

			var data = manager.CreateOrUpdateMilestone(dataModel);

			return RedirectToAction("Milestones", new { projectId = dataModel.result.projectID});
		}

		public IActionResult Edit(string projectId)
		{
			ProjectManager manager = new ProjectManager(_config);
			var data = manager.GetProjectById(projectId);
			return View("Save", data);
		}

		//  [Route("/project/budget/{project-id}")]
		public IActionResult Budget(string projectId)
		{
			ProjectManager manager = new ProjectManager(_config);
			var data = manager.GetBudgets(projectId);

			ResultListBudget resultBudget = new ResultListBudget();
			resultBudget.result = data;
			resultBudget.projectId = projectId;

			return View("Budget/Index", resultBudget);
		}

		//[Route("/project/milestone/{project-id}")]
		public IActionResult Milestones(string projectId)
		{
			ProjectManager manager = new ProjectManager(_config);

			var data = manager.GetMilestones(projectId);

			ResultListMilestone resultMilestone = new ResultListMilestone();
			resultMilestone.result = data;
			resultMilestone.projectId = projectId;

			return View("Milestone/Index", resultMilestone);
		}

		public IActionResult Index()
		{
			ProjectManager manager = new ProjectManager(_config);
			var data = manager.GetProjects();

			return View("Index", data);
		}
	}
}
