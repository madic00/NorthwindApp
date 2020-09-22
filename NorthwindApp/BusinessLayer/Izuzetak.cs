using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.BusinessLayer
{
    public class Izuzetak : Exception
    {
        public Izuzetak(string msg) : base(msg)
        {
        }
    }
}
