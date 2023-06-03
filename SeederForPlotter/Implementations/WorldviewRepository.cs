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
    public class WorldviewRepository : IBaseRepository<Worldview>
    {
        private readonly ApplicationDBContext _db;
        public WorldviewRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task Add()
        {
            var worldviewNames = Worldview.GetArrayNames();
            var worldviewDescriptions = Worldview.GetArrayDescriptions();
            for (int i = 0; i < worldviewNames.Length; i++)
            {
                var worldview = new Worldview()
                {
                    Name = worldviewNames[i],
                    Description = worldviewDescriptions[i],
                };
                await _db.AddAsync(worldview);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete()
        {
            using (SqlConnection con = new SqlConnection(ApplicationDBContext.connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Worldview", con);
                SqlCommand resetId = new SqlCommand("DBCC CHECKIDENT ('[Worldview]', RESEED, 0)", con);
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

        public IQueryable<Worldview> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Worldview> Update(Worldview entity)
        {
            throw new NotImplementedException();
        }
    }
}
