﻿using System;

namespace DataAccessLayer.Models
{
    public sealed class Pilot
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Experience { get; set; }
    }
}
