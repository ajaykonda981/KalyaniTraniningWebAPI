using System.Data.SqlClient;
using System.Data;
using LibraryManagement.Models;
using LibraryManagement.IRepository;

namespace LibraryManagement.Repository
{
    public class SqlRepository: ISqlRepository
    {

        SqlConnection conn = new SqlConnection("Server=INDRANI; Database = LibraryManagement; Trusted_Connection = true");
        SqlCommand? _sqlcommand;
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();

        public SqlRepository()
        {

        }

        private DataTable FilledDataTable(SqlCommand sqlCommand)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataSet);

            dataTable = dataSet.Tables[0];

            return dataTable;
        }

        public string DeleteById(int id, string tableName)
        {
            conn.Open();

            _sqlcommand = new SqlCommand($"DELETE {tableName} WHERE Id = @Id", conn);

            _sqlcommand.Parameters.AddWithValue("@Id", id);

            int rowsAffected = _sqlcommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return $"{tableName} Deleted Successfully.";
            }

            return $"No {tableName} Deleted.";
        }


        public string UpdateById(int id, string tableName, SqlCommand sqlCommand)
        {

            conn.Open();

            int rowsAffected = _sqlcommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return $"{tableName} Updated Successfully.";
            }

            return $"{tableName} Updated.";
        }

        public string Create(SqlCommand sqlCommand, string tableName)
        {
            conn.Open();

            
            int rowsAffected = _sqlcommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                return $"{tableName} Created Successfully.";
            }

            return $"No {tableName} Created.";
        }


        public DataTable Get(SqlCommand sqlCommand)
        {
            conn.Open();
            return FilledDataTable(sqlCommand);
        }
    }
}
