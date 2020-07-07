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
        public static List<tblItem> items = new List<tblItem>();
        public static tblUser currentUser = new tblUser();

        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (OrderDBEntities1 context = new OrderDBEntities1())
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


        public List<tblItem> GetAllItems()
        {
            try
            {
                using (OrderDBEntities1 context = new OrderDBEntities1())
                {
                    List<tblItem> items = new List<tblItem>();
                    items = context.tblItems.ToList();
                    return items;
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
