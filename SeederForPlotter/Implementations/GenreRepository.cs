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
    public class GenreRepository : IBaseRepository<Genre>
    {
        private readonly ApplicationDBContext _db;
        public GenreRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task Add()
        {
            var genres = Genre.GetArrayGenres(); 
            for (int i = 0; i < genres.Length; i++)
            {
                var genre = new Genre()
                {
                    Name = genres[i]
                };
                await _db.AddAsync(genre);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete()
        {
            using (SqlConnection con = new SqlConnection(ApplicationDBContext.connectionString))
            {
                SqlCommand cmd = new("DELETE FROM Genres", con);
                SqlCommand resetId = new ("DBCC CHECKIDENT ('[Genres]', RESEED, 0)", con);
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

        public IQueryable<Genre> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> Update(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
