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
    public class Book_StatusRepository : IBaseRepository<Book_Status>
    {
        private readonly ApplicationDBContext _db;
        public Book_StatusRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task Add()
        {
            var statuses = Book_Status.GetArrayStatuses();
            for (int i = 0; i < statuses.Length; i++)
            {
                var status = new Book_Status()
                {
                    Status = statuses[i],
                };
                await _db.AddAsync(status);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete()
        {
            using (SqlConnection con = new SqlConnection(ApplicationDBContext.connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Statuses", con);
                SqlCommand resetId = new SqlCommand("DBCC CHECKIDENT ('[Statuses]', RESEED, 0)", con);
                try
                {
                    con.Open();
                    resetId.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public IQueryable<Book_Status> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book_Status> Update(Book_Status entity)
        {
            throw new NotImplementedException();
        }
    }
}
