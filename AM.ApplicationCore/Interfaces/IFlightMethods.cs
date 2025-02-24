using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        IEnumerable<DateTime> GetFlightDates(string Destination);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);

    }
}
