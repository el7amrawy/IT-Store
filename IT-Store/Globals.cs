using IT_Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
		[NonAction]
		public static int GetUserId(this Controller controller) {
			if (controller.User.Identity.IsAuthenticated)
			{
				var userIdClaim = controller.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
				return int.Parse(userIdClaim.Value);
			}
			return 0;
        }
		public static List<int> ToListOfInt(this string[] stringArr)
		{
			var list = new List<int>();
			foreach (var item in stringArr)
			{
				list.Add(int.Parse(item));
			}
			return list;
		}
	}
}
