using System;

namespace WebAppAirlineDispatcher.Modules
{
    public class PlaneItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}
