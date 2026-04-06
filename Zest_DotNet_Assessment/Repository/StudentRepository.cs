using Microsoft.Data.SqlClient;
using Zest_DotNet_Assessment.Model;

namespace Zest_DotNet_Assessment.Repository
{
    public class StudentRepository
    {
        private readonly string ConnectionString;

        public StudentRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool InsertStudent(StudentModel std)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", std.Name);
                cmd.Parameters.AddWithValue("@Email", std.Email);
                cmd.Parameters.AddWithValue("@Age", std.Age);
                cmd.Parameters.AddWithValue("@Course", std.Course);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                return rows > 0;
            }
        }

        public List<StudentModel> GetAllStudent()
        {
            List<StudentModel> std = new List<StudentModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    std.Add(new StudentModel
                    {
                        ID = dr["ID"].ToString(),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Age = Convert.ToInt32(dr["Age"]),
                        Course = dr["Course"].ToString(),

                    });
                }
                con.Close();
            }
            return std;
        }

        public List<StudentModel> Get_Student_By_ID(string ID)
        {
            List<StudentModel> std = new List<StudentModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Get_Student_By_ID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    std.Add(new StudentModel
                    {
                        ID = dr["ID"].ToString(),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Age = Convert.ToInt32(dr["Age"]),
                        Course = dr["Course"].ToString(),

                    });
                }
                con.Close();
            }
            return std;
        }

        public bool UpdateStudent(StudentModel std)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", std.ID);
                cmd.Parameters.AddWithValue("@Name", std.Name);
                cmd.Parameters.AddWithValue("@Email", std.Email);
                cmd.Parameters.AddWithValue("@Age", std.Age);
                cmd.Parameters.AddWithValue("@Course", std.Course);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                return rows > 0;
            }
        }

        public bool DeleteStudent(string ID)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", ID);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                return rows > 0;
            }

        }
    }
}
