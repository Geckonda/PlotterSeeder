using Microsoft.Data.SqlClient;
using SeederForPlotter.Interfaces;
using SeederForPlotter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeederForPlotter.Implementations
{
    public class Access_ModificatorRepository : IBaseRepository<Access_Modificator>
    {
        private readonly ApplicationDBContext _db;
        public Access_ModificatorRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task Add()
        {
            var modificators = Access_Modificator.GetArrayModificators();
            for (int i = 0; i < modificators.Length; i++)
            {
                var modificator = new Access_Modificator()
                {
                    Modificator = modificators[i],
                };
                await _db.AddAsync(modificator);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete()
        {
            using (SqlConnection con = new SqlConnection(ApplicationDBContext.connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Modificators", con);
                SqlCommand resetId = new SqlCommand("DBCC CHECKIDENT ('[Modificators]', RESEED, 0)", con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    resetId.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public IQueryable<Access_Modificator> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Access_Modificator> Update(Access_Modificator entity)
        {
            throw new NotImplementedException();
        }
    }
}
