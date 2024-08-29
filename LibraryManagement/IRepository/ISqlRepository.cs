using System.Data;
using System.Data.SqlClient;

namespace LibraryManagement.IRepository
{
    public interface ISqlRepository
    {
        public string DeleteById(int id, string tableName);

        public string UpdateById(int id, string tableName, SqlCommand sqlCommand);

        public string Create(SqlCommand sqlCommand, string tableName);

        public DataTable Get(SqlCommand sqlCommand);
    }
}
