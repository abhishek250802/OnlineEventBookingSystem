using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Model
{
  public class LoginResponse
    {
        public Customer Customer { get; set; }
       
        public string Token { get; set; } 
    }
}