using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OleDb;


namespace TJTutorial6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string GetMeanValue(int value, int value2)
        {
                      
            return ((value + value2) / 2).ToString();
            //return string.Format("You entered: {0}", value);
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

        public string AuthenticateUser(string userid, string password)
        {
            OleDbConnection PubsConn = new OleDbConnection("Provider=SQLOLEDB;Data Source=.\\SQLEXPRESS;" + "integrated Security=sspi;initial catalog=iVolunteer;");
            OleDbCommand testCMD = new OleDbCommand("AuthenticateUser", PubsConn);

            testCMD.CommandType = CommandType.StoredProcedure;
            string status = String.Empty;
            
            OleDbParameter IdIn = testCMD.Parameters.Add
               ("@Userid", OleDbType.VarChar, 20);
            IdIn.Direction = ParameterDirection.Input;
            OleDbParameter NumTitles = testCMD.Parameters.Add
               ("@password", OleDbType.VarChar, 20);
            NumTitles.Direction = ParameterDirection.Input;

            IdIn.Value = userid;
            NumTitles.Value = password;

            PubsConn.Open();

            OleDbDataReader myReader = testCMD.ExecuteReader();
            Console.WriteLine("Book Titles for this Author:");
            while (myReader.Read())
            {
                status = myReader.GetString(0);
            };
            myReader.Close();

            return status;
            


        }
    }
}
