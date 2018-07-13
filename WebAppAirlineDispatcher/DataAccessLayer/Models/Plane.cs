using System;

namespace DataAccessLayer.Models
{
    public sealed class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}
