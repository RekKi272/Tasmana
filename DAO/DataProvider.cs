using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        // Singleton 
        private static DataProvider instance;
        
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }
        private DataProvider() { }

        // private readonly string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=Tasmana;Integrated Security=True;TrustServerCertificate=True";
        private readonly string connectionSTR = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        // Dùng để chạy câu query bình thường hoặc stored procedure
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return data;
        }
        // Thực hiện thêm xóa sửa
        // Trả về số dòng thành công
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    data = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return data;
        }
        // Đếm số lượng, ví dụ COUNT(*)
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteScalar();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return data;
        }
        // Dùng để chạy stored procedure
        // Param + storedprocedure: Tên của stored procedure muốn chạy
        //       + parameters: hashmap chứa biến và giá trị tương ứng của biến đó, ví dụ 1 pair {"@ho", "Trump"} 
        public int ExecuteStoredProcedure(string storedprocedure, Dictionary<string, object> parameters) 
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                try
                {
                    conn.Open();
                    
                    using (SqlCommand cmd = new SqlCommand(storedprocedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p;
                        foreach (var pair in parameters)
                        {
                            Console.WriteLine($"Parameter: {pair.Key}, Value: {pair.Value?.ToString() ?? "null"}");
                            // Get the value of each object
                            object value = pair.Value;
                            if (value != null)
                            {
                                if (value is int intValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.Int) { Value = intValue };
                                else if (value is string stringValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.NVarChar) { Value = stringValue };
                                else if (value is double doubleValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.Float) { Value = doubleValue };
                                else if (value is bool boolValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.Bit) { Value = boolValue };
                                else if (value is byte[] byteValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.VarBinary) { Value = byteValue };
                                else if (value is DateTime dateTimeValue)
                                {
                                    if (dateTimeValue.Year < 1900 || dateTimeValue.Year > 2100)
                                        throw new ArgumentException($"DateTime parameter '{pair.Key}' is out of range.");
                                    p = new SqlParameter(pair.Key, SqlDbType.DateTime2) { Value = dateTimeValue };
                                }
                                else
                                    throw new ArgumentException($"Unsupported data type for parameter: {pair.Key}");
                            }
                            else
                            {
                                p = new SqlParameter(pair.Key, DBNull.Value);
                            }

                            cmd.Parameters.Add(p);
                        }

                        data = cmd.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            return data;
        }

        public Dictionary<string, object> ExecuteStoredProcedureWithOutput(string storedProcedure, Dictionary<string, SqlDbType> outputParameters)
        {
            Dictionary<string, object> outputValues = new Dictionary<string, object>();

            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add output parameters
                        foreach (var param in outputParameters)
                        {
                            SqlParameter outputParam = new SqlParameter(param.Key, param.Value)
                            {
                                Direction = ParameterDirection.Output
                            };

                            // Set the size for string parameters
                            if (param.Value == SqlDbType.VarChar || param.Value == SqlDbType.NVarChar)
                            {
                                // Set an appropriate size, e.g., 100 for VARCHAR(100)
                                outputParam.Size = 300; // You may adjust the size based on your requirements
                            }

                            cmd.Parameters.Add(outputParam);
                        }

                        cmd.ExecuteNonQuery();

                        // Retrieve the values of the output parameters
                        foreach (SqlParameter parameter in cmd.Parameters)
                        {
                            if (parameter.Direction == ParameterDirection.Output)
                            {
                                outputValues.Add(parameter.ParameterName, parameter.Value);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }

            return outputValues;
        }

        public int ExecuteStoredProcedureWithNullValue(string storedprocedure, Dictionary<string, object> parameters)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(storedprocedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var pair in parameters)
                        {
                            Console.WriteLine($"Parameter: {pair.Key}, Value: {pair.Value?.ToString() ?? "null"}");
                            // Get the value of each object
                            object value = pair.Value;

                            // Handle null values
                            if (value == null)
                            {
                                cmd.Parameters.AddWithValue(pair.Key, DBNull.Value);
                            }
                            else
                            {
                                SqlParameter p;
                                if (value is int intValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.Int) { Value = intValue };
                                else if (value is string stringValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.NVarChar) { Value = stringValue };
                                else if (value is double doubleValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.Float) { Value = doubleValue };
                                else if (value is bool boolValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.Bit) { Value = boolValue };
                                else if (value is byte[] byteValue)
                                    p = new SqlParameter(pair.Key, SqlDbType.VarBinary) { Value = byteValue };
                                else if (value is DateTime dateTimeValue)
                                {
                                    if (dateTimeValue.Year < 1900 || dateTimeValue.Year > 2100)
                                        throw new ArgumentException($"DateTime parameter '{pair.Key}' is out of range.");
                                    p = new SqlParameter(pair.Key, SqlDbType.Date) { Value = dateTimeValue };
                                }
                                else
                                    throw new ArgumentException($"Unsupported data type for parameter: {pair.Key}");

                                cmd.Parameters.Add(p);
                            }
                        }

                        data = cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            return data;
        }

        public DataTable ExecuteStoredProcedureWithTableReturn(string storedProcedure, Dictionary<string, object> parameters)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        foreach (var pair in parameters)
                        {
                            SqlParameter parameter = new SqlParameter(pair.Key, pair.Value ?? DBNull.Value);
                            command.Parameters.Add(parameter);
                        }

                        // Execute the command and fill the DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return data;
        }
    }
}
