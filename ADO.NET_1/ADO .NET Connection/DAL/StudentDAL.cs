using ADO.NetConnection.BO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetConnection.DAL
{
    public class StudentDAL
    {
        private readonly string _connectionString;
        public StudentDAL()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            _connectionString = configuration.GetConnectionString("DBConnectionString");
            //_connectionString = "Data Source=localhost;Initial Catalog=Training;Integrated Security=True;TrustServerCertificate=True";
        }
        public List<Student> GetStudents()
        {
            var studentList = new List<Student>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string str = "select * from Student";
                using (SqlCommand command = new SqlCommand(str, sqlConnection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var student = new Student();
                        student.FN = reader["First_Name"] as string;
                        student.LN = reader["Last_Name"] as string;
                        student.RollNo = reader["RollNo"] as int?;
                        student.Marks = reader["Marks"] as double?;
                        studentList.Add(student);
                    }

                    reader.Close();
                    sqlConnection.Close();                    
                }
            }
            return studentList;
        }

        public Student GetStudentByRollNumber(int RollNo)
        {
            var student = new Student();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string str = "select * from Student where RollNo=@RollNo";

                using (SqlCommand command = new SqlCommand(str, sqlConnection))
                {
                    command.Parameters.AddWithValue("@RollNo", RollNo);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        student.FN = reader["First_Name"] as string;
                        student.LN = reader["Last_Name"] as string;
                        student.RollNo = reader["RollNo"] as int?;
                        student.Marks = reader["Marks"] as double?;
                    }

                    reader.Close();
                    sqlConnection.Close();
                }
            }
            return student;
        }

        public bool CreateStudent(Student student)
        {
            bool isSuccess = true;
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string str = "INSERT INTO Student (FIRST_NAME, LAST_NAME,ROLLNO,MARKS) VALUES (@First_Name,@Last_Name,@RollNo,@marks);" +
                        "SET @id=SCOPE_IDENTITY();";
                    int? id = 0;
                    var sqlParamId = new SqlParameter { Direction = System.Data.ParameterDirection.Output, ParameterName = "@id", DbType = System.Data.DbType.Int32};
                   

                    using (SqlCommand command = new SqlCommand(str, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@First_Name", student.FN);
                        command.Parameters.AddWithValue("@Last_Name", student.LN);
                        command.Parameters.AddWithValue("@RollNo", student.RollNo);
                        command.Parameters.AddWithValue("@marks", student.Marks);
                        command.Parameters.Add(sqlParamId);
                        var result = command.ExecuteNonQuery();
                        id = sqlParamId.Value as int?;
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
                Console.WriteLine("An error occurred. " + e.Message);
                throw;
            }
            return isSuccess;
        }

        public bool CreateStudentWithSP(Student student)
        {
            bool isSuccess = true;
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string str = "user_defined";
                    using (SqlCommand command = new SqlCommand(str, sqlConnection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@First_Name", student.FN);
                        command.Parameters.AddWithValue("@Last_Name", student.LN);
                        command.Parameters.AddWithValue("@RollNo", student.RollNo);
                        command.Parameters.AddWithValue("@marks", student.Marks);
                        var result = command.ExecuteScalar();
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
                Console.WriteLine("An error occurred. " + e.Message);
                throw;
            }
            return isSuccess;
        }

        public bool UpdateStudent(Student student)
        {
            bool isSuccess = true;
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string str = "UPDATE Student " +
                        "SET FIRST_NAME=@First_Name, " +
                            "LAST_NAME=@Last_Name,"+
                            "MARKS=@marks " +
                         "WHERE ROLLNO=@RollNo;" ;

                    using (SqlCommand command = new SqlCommand(str, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@First_Name", student.FN);
                        command.Parameters.AddWithValue("@Last_Name", student.LN);
                        command.Parameters.AddWithValue("@RollNo", student.RollNo);
                        command.Parameters.AddWithValue("@marks", student.Marks);
                        var result = command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
                Console.WriteLine("An error occurred. " + e.Message);
                throw;
            }
            return isSuccess;
        }

        public bool DeleteStudent(int rollNumber)
        {
            bool isSuccess = true;
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    string str = "DELETE Student " +Environment.NewLine +
                         "WHERE ROLLNO=@rollNo;";

                    using (SqlCommand command = new SqlCommand(str, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@rollNo", rollNumber);
                        var result = command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
                Console.WriteLine("An error occurred. " + e.Message);
                throw;
            }
            return isSuccess;
        }
    }
}
