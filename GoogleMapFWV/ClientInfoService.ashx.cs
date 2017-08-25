using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleMapFWV
{
    public class ClientInfoService : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            String json = String.Empty;

            //Please change the client id in the Global.asax > Session_Start to view the different client contacts and their address maps
            ClientInfo currentClient = RegistredClients.Clients.SingleOrDefault(c => c.ClientID.Equals(context.Session["CurrentClientID"]));

            if (currentClient != null)
            {
                currentClient.HasInfo = true;
                json = Newtonsoft.Json.JsonConvert.SerializeObject(currentClient);
            }
            else
            {
                json = Newtonsoft.Json.JsonConvert.SerializeObject(new ClientInfo() { });
            }

            HttpContext.Current.Response.Charset = "utf-8";

            HttpContext.Current.Response.ContentType = "application/json";

            HttpContext.Current.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }




    public static class RegistredClients
    {
        public static List<ClientInfo> Clients = new List<ClientInfo>() { 
            new ClientInfo() { ClientID="C-001", FirstName = "Wakil", LastName = "Hasan", PhoneNo = "0061-8874-38775", StreetAddress = "10 Nariel St, St Marys, NSW 2760, Australia" } ,
            new ClientInfo() { ClientID="C-002", FirstName = "Muhammad", LastName = "Kashem", PhoneNo = "880-1191-352163", StreetAddress = "Dhanmond,  Dhaka, Bangladesh" } ,
            new ClientInfo() { ClientID="C-003", FirstName = "Unknown", LastName = String.Empty, PhoneNo = "000-0000-00000", StreetAddress = "Purai Vuaa address" } 
        };
    }


}