using Dayeva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dayeva.Classes
{
    internal class ConnectClass
    {
        public static AuctionContext connect { get; set; } = new AuctionContext();
    }
}
