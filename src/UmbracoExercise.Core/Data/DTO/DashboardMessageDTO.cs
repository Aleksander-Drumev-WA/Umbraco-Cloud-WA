namespace UmbracoExercise.Core.Data.DTO
{
	public record DashboardMessageDTO
	{
        public int Id { get; set; }

        public string Message { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public bool Proceeded { get; set; }
    }
}
