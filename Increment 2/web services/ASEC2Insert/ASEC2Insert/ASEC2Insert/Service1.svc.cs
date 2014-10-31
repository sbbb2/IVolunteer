using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ASEC2Insert
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "insertuser/{uname}/{password}/{name}/{email}/{mobile}/{address}")]
        public string InsertInfo(string uname, string password, string name, string email, string mobile, string address)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand
                ("Insert into usertab(username,password,name,email,mobile,address) values('" + uname + "','" + password + "','" + name + "','" + email + "','" + mobile + "','" + address + "')", conn);


            cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();
            return "inserted";


        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
    public class userde
    {

        public string username { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string address { get; set; }

    }

}
