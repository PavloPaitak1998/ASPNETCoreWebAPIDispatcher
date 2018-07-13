using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public sealed class Crew
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public List<int> StewardessesId { get; set; }
    }
}
