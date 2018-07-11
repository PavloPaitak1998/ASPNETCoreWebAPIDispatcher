
namespace Shared.DTO
{
    public sealed class CrewDTO
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public int[] StewardessesId { get; set; }
    }
}
