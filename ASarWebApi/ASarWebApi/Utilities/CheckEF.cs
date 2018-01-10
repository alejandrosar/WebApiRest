using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASarWebApi.Utilities
{
    public class CheckEF
    {
        //This methods/utilities has created here because we can have more tables in a future.

        //To use before create user method (user without ID)
        public bool CheckUserWithID(UserModel User)
        {
            try
            {
                int id = User.Id;
                string name = User.Name;
                DateTime birthdate = User.Birthdate;
                if (name.Equals(string.Empty) || name.Equals(""))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        //To use before update user method (user with ID)
        public bool CheckUserWithoutID(UserModel User) {
            try
            {
                string name = User.Name;
                DateTime birthdate = User.Birthdate;
                if (name.Equals(string.Empty) || name.Equals(""))
                {
                    return false;
                }
                else {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            
        }
    }
}