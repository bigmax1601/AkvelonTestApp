using System.IO;
using System.Web.Mvc;

namespace AkvelonTestApp.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}


		public ActionResult GetTaskPdf()
		{
			// Simple <a> tag with href to pdf file location is not working in all cases
			// http://stackoverflow.com/questions/14714486/opening-a-pdf-file-directly-in-my-browser

			const string PdfFileName = "DotNet_SDE(T).pdf";
			const string PdfFilePath = "~/Content/Files/";

			Response.AppendHeader("Content-Disposition", $"inline;filename={PdfFileName}");
			return File(Path.Combine(PdfFilePath, PdfFileName), "application/pdf");
		}
	}
}
