using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace wrt.services.shares
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class svShare
    {
        //global
        private string _conectString;
        JavaScriptSerializer serializer = new JavaScriptSerializer() { MaxJsonLength = 2147483647 };
        private string errmsg = null;

        [OperationContract]
        public string get_division(string connectString)
        {
            errmsg = null;

            using (dcShareDataContext dc = new dcShareDataContext(connectString))
            {
                try
                {
                    dc.Connection.Open();
                    var q = from p in dc.Divisions
                            where p.Division_status != 'X'
                            orderby p.Division_code ascending
                            select p;

                    return serializer.Serialize(q);

                }
                catch (Exception e)
                {
                    errmsg = e.Message;
                }
                finally
                {
                    dc.Connection.Close();
                    dc.Dispose();
                }
                return errmsg;
            }
        }

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        public string division_insert_record(string connectString, string data_rec)
        {
            errmsg = null;
            using (dcShareDataContext dc = new dcShareDataContext(connectString))
            {
                try
                {
                    dc.Connection.Open();
                    Division rec = serializer.Deserialize<Division>(data_rec);

                    dc.Divisions.InsertOnSubmit(rec);
                    dc.SubmitChanges();
                }
                catch (Exception e)
                {
                    errmsg = e.Message;
                }
                finally
                {
                    dc.Connection.Close();
                    dc.Dispose();
                }
            }
            return errmsg;
        }

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        public string division_update_record(string connectString, string data_rec)
        {
            errmsg = null;
            using (dcShareDataContext dc = new dcShareDataContext(connectString))
            {
                try
                {
                    dc.Connection.Open();
                    Division rec = serializer.Deserialize<Division>(data_rec);
                    var q = (from p in dc.Divisions
                             where p.Division_code == rec.Division_code
                             select p).First();
                    q.Division_name = rec.Division_name;
                    q.Division_status = rec.Division_status;
                    dc.SubmitChanges();
                }
                catch (Exception e)
                {
                    errmsg = e.Message;
                }
                finally
                {
                    dc.Connection.Close();
                    dc.Dispose();
                }
            }
            return errmsg;
        }

        //delete
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        public string division_delete_record(string connectString, string division_code)
        {
            errmsg = null;
            using (dcShareDataContext dc = new dcShareDataContext(connectString))
            {
                try
                {
                    dc.Connection.Open();

                    var q = from p in dc.Divisions
                            where p.Division_code.Trim() == division_code.Trim()
                            select p;
                    if (q.Count() == 0)
                    {
                        return "Code Not Found";
                    }
                    dc.Divisions.DeleteOnSubmit(q.First());
                    dc.SubmitChanges();
                }
                catch (Exception e)
                {
                    errmsg = e.Message;
                }
                finally
                {
                    dc.Connection.Close();
                    dc.Dispose();
                }
            }
            return errmsg;
        }

        [OperationContract]
        public string get_chat_state(string connectionString)
        {
            _conectString = connectionString;
                       
            #region
                string queryString = "SELECT [chat_state] FROM[dbo].[chat]; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDependency sqld = new SqlDependency(command);
                    sqld.OnChange += Sqld_OnChange;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) { }
                        return "";
                    }
                }
                catch (Exception e)
                {
                    return "*error : " + e.Message;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            #endregion
        }

        private void Sqld_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                var info = e.Info;
                using (dcShareDataContext dc = new dcShareDataContext(_conectString))
                {
                    try
                    {
                        dc.Connection.Open();
                        #region
                        if (info == SqlNotificationInfo.Insert)
                        {
                            hublink.get_data_chat("Insert");
                        }
                        else
                        {
                            if (info == SqlNotificationInfo.Update)
                            {
                                hublink.get_data_chat("Update");
                            }
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        dc.Connection.Close();
                        dc.Dispose();
                    }

                    SqlDependency dependency = sender as SqlDependency;
                    dependency.OnChange -= new OnChangeEventHandler(Sqld_OnChange);

                }
            }
        }
    }
}
