using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Lab3_Template.DTL;


namespace Lab3_Template.DAL
{
    class OrderDAO
    {
        public static IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>();
            try
            {
                DataTable dt = GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    var o = new Order
                    {
                        OrderID = (int)row["OrderID"],
                        PromoCode = row["PromoCode"].ToString(),
                        UserName = row["UserName"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Address = row["Address"].ToString(),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        Country = row["Country"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Email = row["Email"].ToString(),
                        Total = (double) row["Total"]

                    };
                    orders.Add(o);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders.AsEnumerable();
        }
        public static DataTable GetDataTable()
        {
            string sql = "Select * from Orders";
            return DAO.GetDataTable(sql);
          
        }

        static public int GetMaxID()
        {
            int max = -1;
            string sql = "Select Max(OrderID) as MaxID from Orders";
            DataTable dt = DAO.GetDataTable(sql);
            if(dt.Rows.Count > 0) max = (int) dt.Rows[0]["MaxID"];
            return max;
           
        }

        public static bool Insert(Order a)
        {
                SqlCommand cmd = new SqlCommand("Insert into Orders(OrderDate,UserName, FirstName,LastName,Address,City,State,Country,Phone,Email,Total, Promocode) " +
                    "Values(@OrderDate,@UserName, @FirstName,@LastName,@Address,@City,@State,@Country,@Phone,@Email,@Total, @Promocode)");
                cmd.Parameters.AddWithValue("@OrderDate", a.OrderDate);
                cmd.Parameters.AddWithValue("@UserName", a.UserName);
                cmd.Parameters.AddWithValue("@FirstName", a.FirstName);
                cmd.Parameters.AddWithValue("@LastName", a.LastName);
                cmd.Parameters.AddWithValue("@Address", a.Address);
                cmd.Parameters.AddWithValue("@City", a.City); 
                cmd.Parameters.AddWithValue("@State", a.State);
                cmd.Parameters.AddWithValue("@Country", a.Country);
                cmd.Parameters.AddWithValue("@Phone", a.Phone);
                cmd.Parameters.AddWithValue("@Email", a.Email);
                cmd.Parameters.AddWithValue("@Total", a.Total);
                cmd.Parameters.AddWithValue("@Promocode", a.PromoCode);
                return DAO.UpdateTable(cmd);
             

        }

        public static bool Update(Order a)
        {
                SqlCommand cmd = new SqlCommand("Update Orders set OrderDate=@OrderDate, FirstName=@FirstName, LastName=@LastName, " +
                    "Address=@Address, City=@City, State=@State, Country=@Country, Phone=@Phone, Email=@Email WHERE OrderID=@OrderID");
                cmd.Parameters.AddWithValue("@OrderID", a.OrderID);
                cmd.Parameters.AddWithValue("@OrderDate", a.OrderDate);
                cmd.Parameters.AddWithValue("@FirstName", a.FirstName);
                cmd.Parameters.AddWithValue("@LastName", a.LastName);
                cmd.Parameters.AddWithValue("@Address", a.Address);
                cmd.Parameters.AddWithValue("@City", a.City);
                cmd.Parameters.AddWithValue("@State", a.State);
                cmd.Parameters.AddWithValue("@Country", a.Country);
                cmd.Parameters.AddWithValue("@Phone", a.Phone);
                cmd.Parameters.AddWithValue("@Email", a.Email);
            return DAO.UpdateTable(cmd);
        }

        public static bool Delete(Order a)
        {
                SqlCommand cmd = new SqlCommand("Delete from Orders where OrderID=@OrderID");
                cmd.Parameters.AddWithValue("@OrderID", a.OrderID);
                return DAO.UpdateTable(cmd);
        }

        public static DataTable GetOrdersByKeys1(DateTime dateFrom, DateTime dateTo, String firstName, string country)
        {

            string sql = "SELECT * FROM Orders WHERE 1=1 ";
            if (dateFrom.Date.ToString().Length > 0)
            {
                sql = sql + "AND OrderDate >= @dateFrom ";
            }
            if (dateTo.Date.ToString().Length > 0)
            {
                sql = sql + "AND OrderDate <= @dateTo ";
            }
            if (firstName.Length > 0)
            {
                sql = sql + "AND FirstName like '%" + firstName + "%' ";
            }
            if (country.Length > 0)
            {
                sql = sql + "AND Country like '%" + country + "%'";
            }
            SqlCommand cmd = new SqlCommand(sql);
            if (dateFrom.Date.ToString().Length > 0)
            {
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Date);
            }
            if (dateTo.Date.ToString().Length > 0)
            {
                cmd.Parameters.AddWithValue("@dateTo", dateTo.Date);
            }
            return DAO.GetDataTable(cmd);
        }


    }
}
