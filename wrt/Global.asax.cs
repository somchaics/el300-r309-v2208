using System;
using System.Data.SqlClient;
using System.Configuration;

namespace wrt
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["ELDBConnectionString"].ConnectionString);

        }
          
        protected void Application_End(object sender, EventArgs e)
        {
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["ELDBConnectionString"].ConnectionString);
        }
    }
}