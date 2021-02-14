using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETAOP_Session
{
    public class UserSession
    {
        private IConfiguration _configuration;
        public UserSession(IConfiguration Configuration) { _configuration = Configuration; }

        public UserSession() { }

        public int SetUser(User CurrentUser) {

            int id = -1;

            String connection = _configuration.GetConnectionString("localDatabase");
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {

                String username = CurrentUser.getUsername();
                String usermail = CurrentUser.getUsermail();

                string sqlquery = "insert into UserSessions(Username, Usermail) values ('" + username + "', '" + usermail + "' ) " +
                    "select ID from UserSessions where usermail '" + usermail + "'";
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlconn.Open();
                    SqlDataReader reader = sqlcomm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                            Console.WriteLine("id in setUser method in  UserSession.cs: " + id);
                        }
                    }
                    reader.Close();

                }
            }

            return id;
        }

        public User GetUser(int id)
        {
            String username = "";
            String usermail = "";

            String connection = _configuration.GetConnectionString("localDatabase");
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {

                string sqlquery = "select Username, Usermail from UserSessions where ID = '" + id + "'";
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlconn.Open();
                    SqlDataReader reader = sqlcomm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            username = reader.GetString(0);
                            usermail = reader.GetString(1);

                            Console.WriteLine("Username && Usermail in getUser method in  UserSession.cs");
                            Console.WriteLine(username + "," + usermail);
                        }
                    }
                    reader.Close();

                }
            }

            String[] Info = {username, usermail };


            return new User(Info);
        }

    }
}
