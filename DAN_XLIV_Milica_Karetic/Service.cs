using DAN_XLIV_Milica_Karetic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_Milica_Karetic
{
    public class Service
    {
        public static List<tblUser> loggedUser = new List<tblUser>();

        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (OrderDBEntities context = new OrderDBEntities())
                {
                    List<tblUser> users = new List<tblUser>();
                    users = context.tblUsers.ToList();
                    return users;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }
    }
}
