using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Shared
{
    class WorkDay
    {
        //List or two seperated Shifts?
        public List<Shift> Shifts { get; set; }

        public DateTime Date { get; set; }
    }
}
