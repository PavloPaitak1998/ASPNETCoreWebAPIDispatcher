using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Data
{
    public class DataSource : IDataSource
    {
        public List<Flight> FlightList { get; set; } = GetFlights();
        public List<Ticket> TicketList { get; set; } = GetTickets();
        public List<Departure> DepartureList { get; set; } = GetDepartures();
        public List<Stewardess> StewardessList { get; set; } = GetStewardesses();
        public List<Pilot> PilotList { get; set; } = GetPilots();
        public List<Crew> CrewList { get; set; } = GetCrew();
        public List<Plane> PlaneList { get; set; } = GetPlanes();
        public List<PlaneType> PlaneTypeList { get; set; } = GetPlaneTypes();



        //Data
        static List<Flight> GetFlights()
        {
            var flightsList = new List<Flight> {
                new Flight{Number=1111,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,10,18,23,0),Destination="London",DestinationTime=new DateTime(2018,07,11,18,23,0),TicketsId=new int[]{ 1,11} },
                new Flight{Number=2222,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,11,18,23,0),Destination="Tokio",DestinationTime=new DateTime(2018,07,12,18,0,0),TicketsId=new int[]{ 10,20}},
                new Flight{Number=3333,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,12,18,23,0),Destination="Moskow",DestinationTime=new DateTime(2018,07,13,18,23,0),TicketsId=new int[]{ 2,12}},
                new Flight{Number=4444,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,13,18,23,0),Destination="Paris",DestinationTime=new DateTime(2018,07,14,18,23,0),TicketsId=new int[]{ 3,13}},
                new Flight{Number=5555,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,14,18,23,0),Destination="Kiyv",DestinationTime=new DateTime(2018,07,15,18,23,0),TicketsId=new int[]{ 6,16}},
                new Flight{Number=6666,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,15,18,23,0),Destination="Pekin",DestinationTime=new DateTime(2018,07,16,10,23,0),TicketsId=new int[]{ 7,17}},
                new Flight{Number=7777,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,11,18,23,0),Destination="Hong Kong",DestinationTime=new DateTime(2018,07,11,23,49,0),TicketsId=new int[]{ 4,14}},
                new Flight{Number=8888,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,12,18,23,0),Destination="Tbilisi",DestinationTime=new DateTime(2018,07,13,18,23,0),TicketsId=new int[]{ 8,18}},
                new Flight{Number=9999,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,13,8,23,0),Destination="Batumi",DestinationTime=new DateTime(2018,07,13,18,23,0),TicketsId=new int[]{ 5,15}},
                new Flight{Number=1010,PointOfDeparture="Lviv",DepartureTime=new DateTime(2018,07,14,18,23,0),Destination="Varshava",DestinationTime=new DateTime(2018,07,14,22,23,0),TicketsId=new int[]{ 9,19}}
            };

            return flightsList;
        }

        static List<Ticket> GetTickets()
        {
            var ticketsList = new List<Ticket>
            {
                new Ticket{Id=1,Price=100,FlightNumber=1111},
                new Ticket{Id=2,Price=120,FlightNumber=3333},
                new Ticket{Id=3,Price=130,FlightNumber=4444},
                new Ticket{Id=4,Price=140,FlightNumber=7777},
                new Ticket{Id=5,Price=150,FlightNumber=9999},
                new Ticket{Id=6,Price=160,FlightNumber=5555},
                new Ticket{Id=7,Price=100,FlightNumber=6666},
                new Ticket{Id=8,Price=120,FlightNumber=8888},
                new Ticket{Id=9,Price=130,FlightNumber=1010},
                new Ticket{Id=10,Price=130,FlightNumber=2222},
                new Ticket{Id=11,Price=200,FlightNumber=1111},
                new Ticket{Id=12,Price=200,FlightNumber=3333},
                new Ticket{Id=13,Price=200,FlightNumber=4444},
                new Ticket{Id=14,Price=200,FlightNumber=7777},
                new Ticket{Id=15,Price=200,FlightNumber=9999},
                new Ticket{Id=16,Price=200,FlightNumber=5555},
                new Ticket{Id=17,Price=200,FlightNumber=6666},
                new Ticket{Id=18,Price=200,FlightNumber=8888},
                new Ticket{Id=19,Price=200,FlightNumber=1010},
                new Ticket{Id=20,Price=200,FlightNumber=2222},
                new Ticket{Id=21,Price=210},
                new Ticket{Id=22,Price=200}


            };

            return ticketsList;
        }

        static List<Departure> GetDepartures()
        {
            var departuresList = new List<Departure>
            {
                new Departure{Id=1,FlightNumber=1111,Time=new DateTime(2018,07,10,19,23,0),CrewId=1,PlaneId=1},
                new Departure{Id=2,FlightNumber=2222,Time=new DateTime(2018,07,11,18,23,0),CrewId=2,PlaneId=2},
                new Departure{Id=3,FlightNumber=3333,Time=new DateTime(2018,07,12,18,23,0),CrewId=3,PlaneId=3},
                new Departure{Id=4,FlightNumber=4444,Time=new DateTime(2018,07,13,19,23,0),CrewId=4,PlaneId=4},
                new Departure{Id=5,FlightNumber=5555,Time=new DateTime(2018,07,14,18,23,0),CrewId=5,PlaneId=5},
                new Departure{Id=6,FlightNumber=6666,Time=new DateTime(2018,07,15,18,23,0),CrewId=6,PlaneId=6},
                new Departure{Id=7,FlightNumber=7777,Time=new DateTime(2018,07,11,19,23,0),CrewId=7,PlaneId=7},
                new Departure{Id=8,FlightNumber=8888,Time=new DateTime(2018,07,12,18,23,0),CrewId=8,PlaneId=8},
                new Departure{Id=9,FlightNumber=9999,Time=new DateTime(2018,07,13,9,23,0),CrewId=9,PlaneId=9},
                new Departure{Id=10,FlightNumber=1010,Time=new DateTime(2018,07,14,18,23,0),CrewId=10,PlaneId=10},

            };

            return departuresList;
        }

        static List<Stewardess> GetStewardesses()
        {
            var stewardessesList = new List<Stewardess>
            {
                new Stewardess{Id=1,FirstName="Anna",LastName="Piton",BirthDate=DateTime.Parse("12.07.1998")},
                new Stewardess{Id=2,FirstName="Oly",LastName="Pen",BirthDate=DateTime.Parse("28.03.1990")},
                new Stewardess{Id=3,FirstName="Hana",LastName="Toden",BirthDate=DateTime.Parse("12.06.1994")},
                new Stewardess{Id=4,FirstName="Kira",LastName="Grood",BirthDate=DateTime.Parse("01.09.1993")},
                new Stewardess{Id=5,FirstName="Regina",LastName="Draft",BirthDate=DateTime.Parse("15.02.1995")},
                new Stewardess{Id=6,FirstName="Cristy",LastName="Miller",BirthDate=DateTime.Parse("13.01.1998")},
                new Stewardess{Id=7,FirstName="Fiona",LastName="Shvimer",BirthDate=DateTime.Parse("12.12.1993")},
                new Stewardess{Id=8,FirstName="Jasmin",LastName="Simpson",BirthDate=DateTime.Parse("12.07.1997")},
                new Stewardess{Id=9,FirstName="Olena",LastName="Tramp",BirthDate=DateTime.Parse("11.07.1991")},
                new Stewardess{Id=10,FirstName="Maria",LastName="Cruft",BirthDate=DateTime.Parse("18.04.1994")}

            };

            return stewardessesList;
        }

        static List<Pilot> GetPilots()
        {
            var pilotsList = new List<Pilot>
            {
                new Pilot{Id=1,FirstName="Tom",LastName="Piton",BirthDate=DateTime.Parse("12.07.1998"),Experience=1},
                new Pilot{Id=2,FirstName="Ted",LastName="Pen",BirthDate=DateTime.Parse("28.03.1990"),Experience=2},
                new Pilot{Id=3,FirstName="Pavlo",LastName="Toden",BirthDate=DateTime.Parse("12.06.1994"),Experience=3},
                new Pilot{Id=4,FirstName="Jeck",LastName="Grood",BirthDate=DateTime.Parse("01.09.1993"),Experience=5},
                new Pilot{Id=5,FirstName="Jim",LastName="Draft",BirthDate=DateTime.Parse("15.02.1995"),Experience=6},
                new Pilot{Id=6,FirstName="Robin",LastName="Miller",BirthDate=DateTime.Parse("13.01.1998"),Experience=7},
                new Pilot{Id=7,FirstName="Donald",LastName="Shvimer",BirthDate=DateTime.Parse("12.12.1993"),Experience=8},
                new Pilot{Id=8,FirstName="Gage",LastName="Simpson",BirthDate=DateTime.Parse("12.07.1997"),Experience=9},
                new Pilot{Id=9,FirstName="Pavlo",LastName="Tramp",BirthDate=DateTime.Parse("11.07.1991"),Experience=10},
                new Pilot{Id=10,FirstName="Ivan",LastName="Cruft",BirthDate=DateTime.Parse("18.04.1994"),Experience=11}

            };

            return pilotsList;

        }

        static List<Crew> GetCrew()
        {
            var crewList = new List<Crew>
            {
                new Crew{Id=1,PilotId=1,StewardessesId=new int[]{1,2,3,4}},
                new Crew{Id=2,PilotId=2,StewardessesId=new int[]{5,6,7,8}},
                new Crew{Id=3,PilotId=3,StewardessesId=new int[]{9,10}},
                new Crew{Id=4,PilotId=4,StewardessesId=new int[]{1,2,3}},
                new Crew{Id=5,PilotId=5,StewardessesId=new int[]{4,5,6}},
                new Crew{Id=6,PilotId=6,StewardessesId=new int[]{7,8,9}},
                new Crew{Id=7,PilotId=7,StewardessesId=new int[]{10,1,2,3,4,5}},
                new Crew{Id=8,PilotId=8,StewardessesId=new int[]{6,7,8,9,10}},
                new Crew{Id=9,PilotId=9,StewardessesId=new int[]{1,2,3,4}},
                new Crew{Id=10,PilotId=10,StewardessesId=new int[]{5,6,7,8,9,10}}

            };

            return crewList;
        }

        static List<Plane> GetPlanes()
        {
            var planesList = new List<Plane>
            {
                new Plane{Id=1,Name="T-145",TypeId=1,ReleaseDate=DateTime.Parse("12.07.2000"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2000")},
                new Plane{Id=2,Name="AN-15",TypeId=2,ReleaseDate=DateTime.Parse("12.07.2001"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2001")},
                new Plane{Id=3,Name="LY-287",TypeId=3,ReleaseDate=DateTime.Parse("12.07.2002"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2002")},
                new Plane{Id=4,Name="TU-159",TypeId=4,ReleaseDate=DateTime.Parse("12.07.2003"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2003")},
                new Plane{Id=5,Name="CL-11",TypeId=5,ReleaseDate=DateTime.Parse("12.07.2004"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2004")},
                new Plane{Id=6,Name="BOING-789",TypeId=1,ReleaseDate=DateTime.Parse("12.07.2005"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2005")},
                new Plane{Id=7,Name="AN-14",TypeId=2,ReleaseDate=DateTime.Parse("12.07.2006"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2006")},
                new Plane{Id=8,Name="T-145",TypeId=3,ReleaseDate=DateTime.Parse("12.07.2007"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2007")},
                new Plane{Id=9,Name="TU-185",TypeId=4,ReleaseDate=DateTime.Parse("12.07.2008"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2008")},
                new Plane{Id=10,Name="M-168",TypeId=5,ReleaseDate=DateTime.Parse("12.07.2009"),Lifetime=new DateTime(2020,07,12)-DateTime.Parse("12.07.2009")},
            };

            return planesList;
        }

        static List<PlaneType> GetPlaneTypes()
        {
            var planeTypeList = new List<PlaneType> {
                new PlaneType{Id=1,Model="Passenger's",Seats=80,Carrying=47000},
                new PlaneType{Id=2,Model="Passenger's",Seats=120,Carrying=106000},
                new PlaneType{Id=3,Model="Passenger's",Seats=140,Carrying=156000},
                new PlaneType{Id=4,Model="Passenger's",Seats=150,Carrying=206000},
                new PlaneType{Id=5,Model="Passenger's",Seats=240,Carrying=280300},

            };

            return planeTypeList;
        }
    }
}
