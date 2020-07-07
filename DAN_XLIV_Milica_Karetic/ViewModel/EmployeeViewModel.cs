﻿using DAN_XLIV_Milica_Karetic.Commands;
using DAN_XLIV_Milica_Karetic.Model;
using DAN_XLIV_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIV_Milica_Karetic.ViewModel
{
    class EmployeeViewModel : BaseViewModel
    {
        Employee view;
        Service service = new Service();

        #region Property

        private tblOrder order;
        public tblOrder Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }

        private List<tblOrder> orderList;
        public List<tblOrder> OrderList
        {
            get
            {
                return orderList;
            }
            set
            {
                orderList = value;
                OnPropertyChanged("OrderList");
            }
        }

        private Visibility viewOrder = Visibility.Visible;
        public Visibility ViewOrder
        {
            get
            {
                return viewOrder;
            }
            set
            {
                viewOrder = value;
                OnPropertyChanged("ViewOrder");
            }
        }


        #endregion

        #region Constructor
        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="mainOpen">Main window</param>
        public EmployeeViewModel(Employee employeeOpen)
        {
            view = employeeOpen;
            using (OrderDBEntities1 context = new OrderDBEntities1())
            {
                OrderList = context.tblOrders.ToList();
            }
        }
        #endregion

        #region Commands

        private ICommand deleteOrder;
        /// <summary>
        /// Edit student command
        /// </summary>
        public ICommand DeleteOrder
        {
            get
            {
                if (deleteOrder == null)
                {
                    deleteOrder = new RelayCommand(param => DeleteOrderExecute(), param => CaDeleteOrderExecute());
                }
                return deleteOrder;
            }
        }

        /// <summary>
        /// Edit student execute
        /// </summary>
        private void DeleteOrderExecute()
        {
            try
            {
                if (Order != null)
                {
                    int orderId = Order.OrderID;
                    if (Order.OrderStatus == "pending")
                    {
                        service.DenyOrder(orderId);
                        MessageBox.Show("Order denied");
                    }
                    else
                    {
                        service.DeleteOrder(orderId);
                        MessageBox.Show("Order deleted");
                    }
                    using (OrderDBEntities1 context = new OrderDBEntities1())
                    {
                        OrderList = context.tblOrders.ToList();
                    }
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
        private bool CaDeleteOrderExecute()
        {
            if (Order == null)
                return false;
            else
                return true;
        }

        private ICommand approveOrder;
        /// <summary>
        /// Edit student command
        /// </summary>
        public ICommand ApproveOrder
        {
            get
            {
                if (approveOrder == null)
                {
                    approveOrder = new RelayCommand(param => ApproveOrderExecute(), param => CApproveOrderExecute());
                }
                return approveOrder;
            }
        }

        /// <summary>
        /// Edit student execute
        /// </summary>
        private void ApproveOrderExecute()
        {
            try
            {
                if (Order != null)
                {
                    int orderId = Order.OrderID;
                    if (Order.OrderStatus == "pending")
                    {
                        service.ApproveOrder(orderId);
                        MessageBox.Show("Order approved");
                    }
                    else
                    {
                        MessageBox.Show("Order already approved");
                    }
                    using (OrderDBEntities1 context = new OrderDBEntities1())
                    {
                        OrderList = context.tblOrders.ToList();
                    }
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
        private bool CApproveOrderExecute()
        {
            if (Order == null)
                return false;
            else
                return true;
        }
        #endregion
    }
}
