using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3_Template.DTL
{
    public class OrderDetail
    {
        private int orderID;

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        private int orderDetailID;

        public int OrderDetailID
        {
            get { return orderDetailID; }
            set { orderDetailID = value; }
        }
        private int albumID;

        public int AlbumID
        {
            get { return albumID; }
            set { albumID = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private double unitPrice;

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
    }
}
