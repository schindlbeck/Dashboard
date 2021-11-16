using System;

namespace Dash.Data.Models
{
    public class Holiday
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Date.ToShortDateString() + " " + Name;
        }
    }
}
