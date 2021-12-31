using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudOpration.Models
{
    public class StudentHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con = new SqlConnection(constring);
        }

        public List<Student> GetStudent()
        {
            connection();
            List<Student> studentlist = new List<Student>();

            SqlCommand cmd = new SqlCommand("GetStudentList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new Student
                    {
                        StdId = Convert.ToInt32(dr["StdId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        Address = Convert.ToString(dr["Address"]),
                        Mobile = Convert.ToString(dr["Mobile"])
                    });
            }
            return studentlist;
        }


        public bool AddStudent(Student std)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Email", std.Email);
            cmd.Parameters.AddWithValue("@Address", std.Address);
            cmd.Parameters.AddWithValue("@Mobile", std.Mobile);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteStudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool UpdateDetails(Student std,int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", id);
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Email", std.Email);
            cmd.Parameters.AddWithValue("@Address", std.Address);
            cmd.Parameters.AddWithValue("@Mobile", std.Mobile);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
