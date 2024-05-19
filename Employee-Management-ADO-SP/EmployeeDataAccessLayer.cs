using Employee_Management_ADO_SP.Models;
using System.Data.SqlClient;

namespace Employee_Management_ADO_SP
{
    public class EmployeeDataAccessLayer
    {
        // get connection string in cs variable
        string cs = ConnectionString.dbcs;

        // For Showing All Record (Read Operation)
        public List<Employees> getAllEmployees()
        {
            List<Employees> empList = new List<Employees>();

            // using er vitore SqlConnection er object banea use kortase jer jonno amder sql connection close korar dorker ni r, sudhu open kora lagbe.
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAll_Employee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employees emp = new Employees();
                    emp.Id = Convert.ToInt32(reader["ID"]);
                    // ekhan reader["Name"].ToString() theke value pele emp.Name e chole jabe r na pele ?? er pore empty value "" emp.Name e chole gea set hobe.
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.City = reader["City"].ToString() ?? "";
                    emp.Email = reader["Email"].ToString() ?? "";
                    empList.Add(emp);
                }
            }
            return empList;
        }

        // For Adding Record (Create Operation)
        public void AddEmployee (Employees emp)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SP_Add_Employee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    
        // single data will return using id
        public Employees getEmployeeByID(int? id)
        {
            Employees emp = new Employees();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Employees where id=@id", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["ID"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.City = reader["City"].ToString() ?? "";
                    emp.Email = reader["Email"].ToString() ?? "";
                }
            }
            return emp;
        }

        // For Updating Record (Update Operation)
        public void UpdateEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SP_Update_Employee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", emp.Id); // update er jonno Id pathano lagbei.
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // For Deleting Record (Delete Operation)
        public void DeleteEmployee(int? id) 
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SP_Delete_Employee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id); // delete er jonno Id pathano lagbei.
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
