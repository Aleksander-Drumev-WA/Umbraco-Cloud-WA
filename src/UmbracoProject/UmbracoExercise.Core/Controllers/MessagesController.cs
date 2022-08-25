using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoExercise.Core.Data.DTO;
using UmbracoExercise.Core.Data.Services;

namespace UmbracoExercise.Core.Controllers
{
	public class MessagesController : UmbracoApiController
	{
		private readonly MessagesDataService _messagesDataService;

		public MessagesController(MessagesDataService messagesDataService)
		{
			_messagesDataService = messagesDataService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var messages = _messagesDataService.GetAll();

			return Ok(messages);
		}

		[HttpPut]
		public IActionResult Update([FromBody] ChangeMessageStateRequest model)
		{
			var result = _messagesDataService.SwitchMessageState(model);

			return Ok(result);
		}

		[HttpDelete]
		public IActionResult Delete(DeleteMessageRequest request)
		{
			var result = _messagesDataService.DeleteMessage(request);

			return Ok(result);
		}
	}
}
