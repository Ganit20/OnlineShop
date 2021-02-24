using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop
{
    public class StaticInfo
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserRole { get; set; }
        public static int UserId{ get; set; }
        public static bool IsAdmin {
            get 
            {
                if (UserRole == "Admin")
                    return true;
                else
                    return false;
            } }
    }
}
