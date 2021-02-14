using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETAOP_Session
{
    public class User
    {
        public String[] UserInfo = new String[2];
        //0 - username
        //1 - usermail

        public static readonly User CurrentUser = new User();

        public User(String[] UserInfo)
        {
            this.UserInfo = UserInfo;
        }

        public User(String username, String mail)
        {
            UserInfo[0] = username;
            UserInfo[1] = mail;
        }

        public User(){}

        public void setUsername( String Username) { this.UserInfo[0] = Username; }
        public void setMail(String mail) { this.UserInfo[1] = mail; }

        public String getUsername() { return UserInfo[0]; }
        public String getUsermail() { return UserInfo[1]; }
    }
}
