using DAN_XLIV_Milica_Karetic.Commands;
using DAN_XLIV_Milica_Karetic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLIV_Milica_Karetic.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        MainWindow main; 

        #region Property

        private tblItem item;
        public tblItem Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
        }

        private List<tblItem> itemList;
        public List<tblItem> ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
                OnPropertyChanged("ItemList");
            }
        }

        private Visibility viewItem = Visibility.Visible;
        public Visibility ViewItem
        {
            get
            {
                return viewItem;
            }
            set
            {
                viewItem = value;
                OnPropertyChanged("ViewItem");
            }
        }

        
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="mainOpen">Main window</param>
        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            using (OrderDBEntities1 context = new OrderDBEntities1())
            {
                ItemList = context.tblItems.ToList();
            }
        }
        #endregion

        #region Commands

        private ICommand addItem;
        /// <summary>
        /// Edit student command
        /// </summary>
        public ICommand AddItem
        {
            get
            {
                if (addItem == null)
                {
                    addItem = new RelayCommand(param => AddItemExecute(), param => CaAddItemExecute());
                }
                return addItem;
            }
        }

        /// <summary>
        /// Edit student execute
        /// </summary>
        private void AddItemExecute()
        {
            try
            {
                if (Item != null)
                {
                    OrderDBEntities1 db = new OrderDBEntities1();
                    tblOrder order = new tblOrder();
                    string quantityItem = MainWindow.quantity;
                    DateTime dateNow = DateTime.Now;

                    order.TotalPrice = Item.ItemPrice * int.Parse(quantityItem);
                    order.OrderStatus = "cekanje";
                    order.OrderCreated = dateNow;
                    order.UserID = Service.currentUser.UserID;
                    order.ItemID = Item.ItemID;

                    db.tblOrders.Add(order);
                    db.SaveChanges();


                    //AddStudent addStudent = new AddStudent(Student);
                    //addStudent.ShowDialog();
                    //if ((addStudent.DataContext as AddStudentViewModel).IsUpdateStudent == true)
                    //{
                    //    using (Service1Client wcf = new Service1Client())
                    //    {
                    //        StudentList = wcf.GetAllStudents().ToList();
                    //    }
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can edit student execute
        /// </summary>
        /// <returns>Can or cannot</returns>
        private bool CaAddItemExecute()
        {
            if (Item == null)
                return false;
            else
                return true;
        }


        #endregion
    }
}
