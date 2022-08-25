using Microsoft.AspNetCore.Mvc;
using UmbracoExercise.Core.Data.DTO;
using UmbracoExercise.Core.Data.Services;

namespace UmbracoExercise.Core.Controllers
{
	public class ContactController : Controller
	{
		private readonly MessagesDataService _messagesDataService;

		public ContactController(MessagesDataService messagesDataService)
		{
			_messagesDataService = messagesDataService;
		}

		[HttpPost]
		public async Task<IActionResult> Submit(ContactRequestModel model)
		{
			await _messagesDataService.CreateMessageAsync(model);

			return Redirect("/contact");
		}

		[HttpGet]
		public IActionResult Render()
		{
			return View("/Views/Contact.cshtml");
		}
	}
}
