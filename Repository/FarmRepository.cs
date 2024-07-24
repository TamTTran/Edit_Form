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
                return db.Query<FarmModel>("SELECT * FROM db_test");
            }
        }

        public FarmModel GetFarmModelById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<FarmModel>("SELECT * FROM FarmModels WHERE Id = @Id", new { Id = id });
            }
        }

        public void AddFarmModel(FarmModel user)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "INSERT INTO FarmModels (Name, Email) VALUES(@Name, @Email)";
                db.Execute(sqlQuery, user);
            }
        }

        public void UpdateFarmModel(FarmModel user)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "UPDATE FarmModels SET Name = @Name, Email = @Email WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void DeleteFarmModel(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "DELETE FROM FarmModels WHERE Id = @Id";
                db.Execute(sqlQuery, new { Id = id });
            }
        }
    }
}