using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public int PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        //Question 10)a) maghir email w b hedhi kemla 
        public bool CheckProfile(string firstname, string lastname, string email)
        {
            return FirstName == firstname && LastName == lastname && EmailAddress == email;
        }

        //Question 10)c) //ken da5el mail nthabbét fih sinn mana3mel chay
        public bool CheckProfile2(string firstname, string lastname, string email)
        {
            if (email != null)
                return FirstName == firstname && FirstName == lastname && EmailAddress == email;
            else
                return FirstName == firstname && LastName == lastname;
        }

        //Question 11)a) polymorphisme par héritage //virtual bech najmo nesta3mlouha fel classe fille fi blaset override mta java
        public virtual void PassengerType()
        {
            Console.WriteLine("I'm a Passenger");
        }

        public override string? ToString()
        {
            return "First name : " + FirstName + "Last name : " + LastName +  "BirthDate " + BirthDate;
        }
    }

    
}
