using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dash.Data.Models
{
    public class DbWorkDay
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ProductionMinutes { get; set; }

        public string DetailInfo { get; set; }
    }
}
