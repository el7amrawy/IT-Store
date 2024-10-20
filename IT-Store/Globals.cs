using Microsoft.AspNetCore.Mvc;

namespace IT_Store
{
	public static class ExtendedMethodes
	{
		[NonAction]
		public static IActionResult RedirectToReferer(this Controller controller)
		{
			var refer = controller.Request.Headers["Referer"].ToString();
			if (refer.Length > 0)
			{
				return controller.Redirect(refer);
			}
			return controller.RedirectToAction("", "Home");
		}
	}
}
