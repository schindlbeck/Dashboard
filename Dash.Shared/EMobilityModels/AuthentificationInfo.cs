using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMobility.Models
{
    //[Table("AuthentificationStates")]
    public class AuthentificationInfo
    {
        public string Location { get; set; } = string.Empty;
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string AuthState { get; set; } = string.Empty;
        public string AuthID { get; set; } = string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(Location).Append('/')
            .Append(TimeStamp).Append('/')
            .Append(AuthState).Append('/')
            .Append(AuthID);

            return sb.ToString();
        }
    }
}
