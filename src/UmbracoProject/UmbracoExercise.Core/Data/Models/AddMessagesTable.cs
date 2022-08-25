using NPoco;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace UmbracoExercise.Core.Data.Models
{
    public class AddMessagesTable : MigrationBase
    {
        public AddMessagesTable(IMigrationContext context) : base(context)
        {
        }
        protected override void Migrate()
        {
            if (TableExists("Messages") == false)
            {
                Create.Table<MessagesSchema>().Do();
            }
            else
            {
                throw new InvalidOperationException(string.Format("The database table {DbTable} already exists, skipping", "Messages"));
            }
        }

        [TableName("Messages")]
        [PrimaryKey("Id", AutoIncrement = true)]
        [ExplicitColumns]
        public class MessagesSchema
        {
            [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1)]
            [Column("Id")]
            public int Id { get; set; }

            [Column("SenderName")]
            public string SenderName { get; set; }

            [Column("SenderEmail")]

            public string SenderEmail { get; set; }

            [Column("Message")]
            public string Message { get; set; }

            [Column("CreatedOn")]
            public DateTime CreatedOn { get; set; }

            [Column("Proceeded")]
            public bool Proceeded { get; set; }

        }
    }
}
