namespace UmbracoExercise.Core.Data.DTO
{
    public record ChangeMessageStateRequest
    {
        public int Id { get; set; }

        public bool Proceeded { get; set; }
    }
}
