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

        public void DeleteOrder(int orderID)
        {
            try
            {
                using (OrderDBEntities1 context = new OrderDBEntities1())
                {
                    tblOrder orderToDelete = (from r in context.tblOrders where r.OrderID == orderID select r).First();
                    context.tblOrders.Remove(orderToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void DenyOrder(int orderID)
        {
            try
            {
                using (OrderDBEntities1 context = new OrderDBEntities1())
                {
                    tblOrder orderToDeny = (from r in context.tblOrders where r.OrderID == orderID select r).First();
                    orderToDeny.OrderStatus = "denied";
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public List<tblOrder> GetAllOrders()
        {
            try
            {
                using (OrderDBEntities1 context = new OrderDBEntities1())
                {
                    List<tblOrder> orders = new List<tblOrder>();
                    orders = context.tblOrders.ToList();
                    return orders;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public void ApproveOrder(int orderID)
        {
            try
            {
                using (OrderDBEntities1 context = new OrderDBEntities1())
                {
                    tblOrder orderToDeny = (from r in context.tblOrders where r.OrderID == orderID select r).First();
                    orderToDeny.OrderStatus = "approved";
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        public bool CheckOrderStatus(int userID)
        {
            int a = 0;
            try
            {
                using (OrderDBEntities1 context = new OrderDBEntities1())
                {
                    List<tblOrder> orders = new List<tblOrder>();
                    orders = context.tblOrders.ToList();

                    List<tblOrder> userOrders = orders.Where(u => u.UserID == userID).ToList();

                    for (int i = 0; i < userOrders.Count; i++)
                    {
                        if (userOrders[i].OrderStatus == "pending")
                            a++;
                    }
                    
                }
                if (a > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }
    }
}
