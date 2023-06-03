using Azure;
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
    public class RoleRepository : IBaseRepository<Role>
    {

        private readonly ApplicationDBContext _db;
        public RoleRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task Add()
        {
            var roles = Role.GetArrayRoles();
            for (int i = 0; i < roles.Length; i++)
            {
                var role = new Role()
                {
                    Name = roles[i],
                };
                await _db.AddAsync(role);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete()
        {
            using (SqlConnection con = new SqlConnection(ApplicationDBContext.connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Roles", con);
                SqlCommand resetId = new SqlCommand("DBCC CHECKIDENT ('[Roles]', RESEED, 0)", con);
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

        public IQueryable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
