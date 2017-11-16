using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Classes;

namespace Task3.Interfaces
{
  public  interface IPort: IClearEventHandlers
    {
        PortStatus Status { get; set; }
        event EventHandler<PortStatus> StatusChanging;
        event EventHandler<PortStatus> StatusChanged;

    }
}
