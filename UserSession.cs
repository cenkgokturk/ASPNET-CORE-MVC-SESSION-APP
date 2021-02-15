using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
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

            Console.WriteLine("****** SetUser Entry");

            int id = -1;

            String connection = "Data Source=DESKTOP-II1M7LK;Initial Catalog=AccountDb;Integrated Security=True";
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {
                String username = CurrentUser.getUsername();
                String usermail = CurrentUser.getUsermail();

                string sqlquery = "insert into UserSessions(Username, Usermail) values ('" + username + "', '" + usermail + "' )";
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                }
            }

            id = GetSessionToken(CurrentUser);

            return id;
        }

        private int GetSessionToken(User CurrentUser)
        {
            Console.WriteLine("****** GetSessionToken Entry");
            int id = -1;

            String connection = "Data Source=DESKTOP-II1M7LK;Initial Catalog=AccountDb;Integrated Security=True";
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {

                String usermail = CurrentUser.getUsermail();

                Console.WriteLine("****** GetSessionToken Mail received");

                string sqlquery = "select ID from UserSessions where Usermail = '" + usermail + "'";
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

            Console.WriteLine("****** GetSessionToken Exit");

            return id;
        }

        public User GetUser(int id)
        {
            String username = "";
            String usermail = "";

            String connection = "Data Source=DESKTOP-II1M7LK;Initial Catalog=AccountDb;Integrated Security=True";
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
