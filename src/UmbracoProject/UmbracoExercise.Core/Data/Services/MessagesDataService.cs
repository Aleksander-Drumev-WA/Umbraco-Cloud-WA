using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Infrastructure.Persistence;
using UmbracoExercise.Core.Data.DTO;
using static UmbracoExercise.Core.Data.Models.AddMessagesTable;

namespace UmbracoExercise.Core.Data.Services
{
	public class MessagesDataService
	{
		private readonly IScopeProvider _scopeProvider;

		public MessagesDataService(IScopeProvider scopeProvider)
		{
			_scopeProvider = scopeProvider;
		}

		public async Task CreateMessageAsync(ContactRequestModel model)
		{
			var modelForDb = new MessagesSchema()
			{
				SenderName = model.Name,
				SenderEmail = model.Email,
				Message = model.Message,
				CreatedOn = DateTime.UtcNow,
			};
			using (var scope = _scopeProvider.CreateScope(autoComplete: true))
			{
				await scope.Database.InsertAsync("Messages", "Id", modelForDb);
			}
		}

		public IEnumerable<DashboardMessageDTO> GetAll()
		{
			IEnumerable<DashboardMessageDTO> messagesFromDb;

			using (var scope = _scopeProvider.CreateScope(autoComplete: true))
			{
				var sql = scope.SqlContext.Sql("SELECT [Id], [Message], [CreatedOn], [Proceeded] FROM Messages")
						.OrderBy<MessagesSchema>(f => f.CreatedOn);

				messagesFromDb = scope.Database.Query<MessagesSchema>(sql)
					.Select(x => new DashboardMessageDTO
					{
						Id = x.Id,
						Message = x.Message,
						CreatedOn = x.CreatedOn.ToString("dd MMMM yyyy"),
						Proceeded = x.Proceeded
					});
			}

			return messagesFromDb;
		}

		public int SwitchMessageState(ChangeMessageStateRequest model)
		{
			var changedEntityId = 0;

			using (var scope = _scopeProvider.CreateScope(autoComplete: true))
			{
				var sql = scope.SqlContext.Sql(string.Format("SELECT * FROM Messages WHERE [Id]={0}", model.Id));

				var dbEntity = scope.Database.Query<MessagesSchema>(sql).FirstOrDefault();
				dbEntity.Proceeded = model.Proceeded;
				scope.Database.Save(dbEntity);
				changedEntityId = dbEntity.Id;
			}

			return changedEntityId;
		}

		public int DeleteMessage(DeleteMessageRequest request)
		{
			var deletedMessageId = 0;

			using (var scope = _scopeProvider.CreateScope(autoComplete: true))
			{
				var sql = scope.SqlContext.Sql(string.Format("SELECT * FROM Messages WHERE [Id]={0}", request.Id));

				var dbEntity = scope.Database.Query<MessagesSchema>(sql).FirstOrDefault();
				deletedMessageId = dbEntity.Id;
				scope.Database.Delete("Messages", "Id", dbEntity);
			}

			return deletedMessageId;
		}
	}
}
