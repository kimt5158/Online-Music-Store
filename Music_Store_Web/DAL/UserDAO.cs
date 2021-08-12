using Lab3_Template.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lab3_Template.DAL
{
    public class UserDAO
    {
        public static IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                DataTable dt = GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    var user = new User
                    {
                        Id = (int)row["ID"],
                        UserName = row["UserName"].ToString(),
                        Password = row["Password"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Address = row["Address"].ToString(),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        Country = row["Country"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Email = row["Email"].ToString(),
                        Role = (int)row["Role"]
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users.AsEnumerable();

        }
        public static DataTable GetDataTable()
        {
            return DAO.GetDataTable("SELECT * FROM users");
        }

    }
}
