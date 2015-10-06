using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleMapFWV
{
    public class ClientInfo
    {
        public Boolean HasInfo { get; set; }
        public String ClientID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String StreetAddress { get; set; }
        public String PhoneNo { get; set; }
    }
}