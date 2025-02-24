using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public IEnumerable<DateTime> GetFlightDates(String destination)//chnraj3o lista kahaw //question 6 partie 2 
        {
            IEnumerable<DateTime> result = new List<DateTime>();  //kenet List badlneha IEnumerable bech najmo nekdhmo beha fel LINQ w lamda
            //    for (int i = 0; i < Flights.Count; i++)
            //    {
            //        if (Flights[i].Destination.Equals(destination))
            //        {
            //            result.Add(Flights[i].FlightDate);
            //        }
            //        return result;
            //    }
            //    foreach (Flight f in Flights) //QUESTION 7
            //    {
            //        result.Add(f.FlightDate);
            //    }
            //    return result;
            //}


            ////language LINQ
            //var query = from instance in Collection
            //            where condition
            //            select retour;
            //return query;



            result = from f in Flights
                     where f.Destination.Equals(destination)
                     select f.FlightDate;
            return result;

            //LAMDA expression
            result = Flights.Where(f => f.Destination.Equals(destination))
                    .Select(f => f.FlightDate);
            return result;
            //f select ki theb trajaa akther men haja taaml
            // Select(f=> new{f.FlighDate , ....});
        }
        //QUESTION 8 
        public List<Flight> GetFlights(string filterType, string filterValue) //QUESTION 10
        {
            List<Flight> result = new List<Flight>();

            foreach (Flight f in Flights)
            {
                switch (filterType.ToLower())
                {
                    case "destination":
                        if (f.Destination.Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                        {
                            result.Add(f);
                        }
                        break;

                    case "estimatedduration":
                        if (f.EstimatedDuration.ToString() == filterValue)
                        {
                            result.Add(f);
                        }
                        break;

                    case "flightdate":
                        if (f.FlightDate.ToString("yyyy-MM-dd") == filterValue)
                        {
                            result.Add(f);
                        }
                        break;

                    default:
                        Console.WriteLine("Filtre non reconnu.");
                        break;
                }
            }

            return result;
        }

        //Qestion 10 
        public void ShowFlightDetails(Plane plane) //BEL LINQ
        {
            var req = from f in Flights
                      where f.Plane == plane
                      select new {f.Destination, f.FlightDate };
            foreach (var f in req)
            {
                Console.WriteLine(f); //3malna foreach 5ater chnaamlo affichage mta3 2 resultats
                // Personnalisation de l'affichage                      
               Console.WriteLine($" METHODE 2 : Destination: {f.Destination}, Flight Date: {f.FlightDate.ToString("dd/MM/yyyy HH:mm:ss")}");
            }
        }
        //question 11
        //public int ProgrammedFlightNumber(DateTime startDate)
        //{
        //    // Calculer la date de fin de la période de 7 jours
        //    DateTime endDate = startDate.AddDays(7);

        //    int flightCount = (from f in Flights
        //                       where f.FlightDate >= startDate && f.FlightDate <= endDate
        //                       select f) .Count();  //nzidou .Count() chne7sbo 9adeh men wehed lkina

        //    return flightCount;
        //}

        //ou bien ; hédhi asa7
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where DateTime.Compare(startDate, f.FlightDate) < 0 //nchouf ken date de vol ba3d startDate yani par exemple date vol nhar 5mis w startDate nebda n9aren bih nhar thnin donc lezem < 0 yani 5mis akber men thnin
                      && (f.FlightDate - startDate).TotalDays < 8 // mabin startDate w date de vol a9al men 8 ayem yaani ma7soura fi jem3a
                      select f;
            return req.Count();
        }


        //QUESTION 12
        public double DurationAverage(string destination)
        {
            // Filtrer les vols par destination et calculer la somme des durées estimées
            var req = from f in Flights
                               where f.Destination == destination
                               select f.EstimatedDuration;

            // Calculer la moyenne des durées estimées
            //double averageDuration = dureeMoyenne.Sum() / (double)dureeMoyenne.Count();

            return req.Average();
        }

        //Question 13

        public IEnumerable<Flight>OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;
            return req;
        } 

       // i love u <3
       //Question 14

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var req = from t in flight.Passengers.OfType<Traveller>()
                      orderby t.BirthDate
                      select t; 
            return req.Take(3);
            //skip(3) ignorer les 3 premiers
        }
        //Question 15
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

                      foreach ( var g in req)
            {
                Console.WriteLine("Destination : " + g.Key); 
                foreach (Flight f in g)
                    Console.WriteLine(f);
            }
                      return req;
        }

    }
}
