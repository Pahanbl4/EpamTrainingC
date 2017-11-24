using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
    public interface ICallingArgsEvent
    {
        int TelephoneNumber { get; }
        int ObjectTelephoneNumber { get; }
        int Id { get; }
    }
}
