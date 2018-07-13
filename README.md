# ASP .NET Core Web API Dispatcher
A simple ASP .NET Core Web API App which presents work of airline dispatchers.

## Discription App

The airport serves flights with scheduled flights. Date / Time of departure may differ from the time of departure of the flight - for example, if the flight was delayed, the time of departure will be delayed accordingly. For the departure, the aircraft and crew are appointed. The crew consists of a pilot (1) and stewardesses (1 or more). Aircraft that belong to the airport have a service life depending on the type of aircraft and require timely maintenance.

We as dispatchers must have CRUD operations on all entities.

### Classes should look like this:

   * Flights (flight number, departure point, departure time, destination, time of arrival at the destination place, tickets)

   * Ticket (Id, price, flight number)

   * Departures (Id, flight number, departure date, crew, airplane)

   * Stewardesses (Id, Name, Surname, Date of Birth)

   * Pilots (Id, Name, Surname, Date of Birth, Experience (eg 3 years))

   * Crew (Id, Pilot (1), Stewardesses (1 or more)

   * Airplane (Id, Airplane name, Airplane type, Airplane release date, TimeSpan)

   * Types of aircraft (Id, model aircraft, number of seats, load capacity (kg))
   
### Aim of this project
   
   Create a project ASP.NET Core WebAPI and realize endpoints which described above. Create a model for all the structure which above. Also you need add some seeds data which will download by default.
   
## Important:

1) Split all logic on the layer: Presentation Layer - controller, Business Layer - service, Data Access Layer - repository.

2) Use the IoC container, that is to break all the logic into different services and create abstractions for them (all for IoC and Dependency Inversion Principle).

3) Have two sets of classes: DTO and Model. Use mapping (you can use the AutoMapper library).

4) Add Validation (FluentValidation library can be used if desired)

5) To work with data, implement one of the approaches described in the lecture, or if you know something else that you think is best suited for this task. However, keep them in memory. (You do not need to implement operations with a real database!).

#### Have fun)


 _"Motivation is good, but not the answer to keep you going in the long run. Become passionate about what you do."_

– Yad Faeq 
