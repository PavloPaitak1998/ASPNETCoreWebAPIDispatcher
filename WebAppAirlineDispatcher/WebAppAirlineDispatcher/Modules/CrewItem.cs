using System.Collections.Generic;

namespace WebAppAirlineDispatcher.Modules
{
    public class CrewItem
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public List<int> StewardessesId { get; set; }
    }
}
