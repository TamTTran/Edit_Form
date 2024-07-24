using Dapper;
using Edit_Info.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Edit_Info.Repository
{
    public class FarmRepository
    {
        public readonly string _connectionString;

        public FarmRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<FarmModel> GetAllFarmModels()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<FarmModel>("SELECT * FROM tb_test");
            }
        }

        
    }
}