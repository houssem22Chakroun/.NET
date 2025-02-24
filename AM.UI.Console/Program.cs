// See https://aka.ms/new-console-template for more information


using System.ComponentModel.Design;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");
//Question 7 
Plane plane1 = new Plane();

plane1.PlaneType = PlaneType.Airbus;
plane1.Capacity = 200;
plane1.ManufactureDate = new DateTime(2018, 11, 10);

//Question 8

Plane plane2 = new Plane(300,DateTime.Now,PlaneType.Boing);

//Question 9 // bech nwaliw maadech naamlo constructeur param / no param nwlai b initliliseur d objet directement b {}

Plane plane3 = new Plane { PlaneType = PlaneType.Airbus, Capacity = 100 };

//Question 11)c

Passenger p1 = new Passenger { FirstName="Aymen", LastName="Thabet", EmailAddress="Aymen.thabet@esprit.tn"};
Console.WriteLine(p1.CheckProfile("Aymen", "Thabet", "Aymen.thabet@esprit.tn"));
p1.PassengerType();
Staff s1 = new Staff { EmployementDate =new DateTime(2019,05,09), FirstName = "staff l 3arf" };
s1.PassengerType(); 
   

//Partie 2 , question 5
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;


// TEST GetFlightDates mta3 LINQ
Console.WriteLine("/Partie Service ");
Console.WriteLine("La methode GetFlightDates");

foreach (var f in fm.GetFlightDates("Madrid"))
{
    Console.WriteLine(f);
}

//test Question8 
List<Flight> flightsToParis = fm.GetFlights("Destination", "Paris");
Console.WriteLine("Vols vers Paris :");
foreach (var flight in flightsToParis)
{
    Console.WriteLine($"Flight Date: {flight.FlightDate.ToString("dd/MM/yyyy HH:mm:ss")}, Flight ID: {flight.FlightId}, Destination: {flight.Destination}, Plane: {flight.Plane}, Estimated Duration: {flight.EstimatedDuration} mins");
}

//test Question 10
Console.WriteLine("*************QUESTION 10******************");

Console.WriteLine("TEST QUESTION 10 . date + destination");
fm.ShowFlightDetails(TestData.BoingPlane);


//test Question 11

int x = fm.ProgrammedFlightNumber(new DateTime(2022,02,02));
Console.WriteLine("************** Question 11*********** : nombre de vol aparatir d une date donné");
Console.WriteLine(x);

//test Question 12
double y = fm.DurationAverage("Lisbonne");
Console.WriteLine(y);

//test Question 13
Console.WriteLine("**************QUESTION 13 ***************************");
foreach (Flight f in fm.OrderedDurationFlights())
{
    Console.WriteLine(f);
}


//test Question 14
Console.WriteLine("***************************QUESTION 14 ********************************* \n");
foreach (Traveller t in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(t); 
}

//test Question 15
Console.WriteLine("*********QUESTION 15************ : GROUPED FLIGHTS BY DESTINATION \n ");
fm.DestinationGroupedFlights();