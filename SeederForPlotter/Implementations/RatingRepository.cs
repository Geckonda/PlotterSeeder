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
    public class RatingRepository : IBaseRepository<Rating>
    {
        private readonly ApplicationDBContext _db;

        public RatingRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task Add()
        {
            var ratings = Rating.GetArrayRating();
            for (int i = 0; i < ratings.Length; i++)
            {
                var rate = new Rating()
                {
                    Rate = ratings[i],
                };
                await _db.AddAsync(rate);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete()
        {
            using (SqlConnection con = new SqlConnection(ApplicationDBContext.connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Ratings", con);
                SqlCommand resetId = new SqlCommand("DBCC CHECKIDENT ('[Ratings]', RESEED, 0)", con);
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

        public IQueryable<Rating> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Rating> Update(Rating entity)
        {
            throw new NotImplementedException();
        }
    }
}
