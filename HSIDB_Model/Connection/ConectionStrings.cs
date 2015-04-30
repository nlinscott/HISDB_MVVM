using System;

namespace HISDB_Model.Connection
{
    internal static class ConectionStrings
    {
     
       public static string DriverString
       {
           get 
           {
               return String.Format("{0}{1}{2}", _server, _db, _security); 
           }
       }

       //"Data Source=localhost;Initial Catalog=HISDB;User Id=Secretary;Password=abc123;";

        //server name
       private static string _server = "Data Source=localhost;";
       private static string _db = "Initial Catalog=HISDB;";

        //Uncomment if you set a username/password
       //private static string _userId = @"User Id=;";
       //private static string _pass = "Password='';";

        //ifyou used the security to the local machine, use this
        private static string _security = "Integrated Security = true;";
    }
}
