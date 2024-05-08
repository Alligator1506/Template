using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Template.Models;
using Template.Models.Tables;

namespace Template.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			using (var db = new dotnet1_blog_demoContext())
			{
				var indexViewModel = new IndexViewModel();
				var categories = db.Categories.ToList();
				indexViewModel.Categories = categories;
				return View(indexViewModel);
			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}

	public partial class IndexViewModel
	{
		public List<Category> Categories { get; set; }
	}
}
