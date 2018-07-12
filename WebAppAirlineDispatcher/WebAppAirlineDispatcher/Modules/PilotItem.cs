using System;

namespace WebAppAirlineDispatcher.Modules
{
    public class PilotItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Experience { get; set; }
    }
}
