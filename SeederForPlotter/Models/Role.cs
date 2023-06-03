using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeederForPlotter.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public static string[] GetArrayRoles()
        {
            return new string[3]
            {
                "Admin",
                "Moderator",
                "User",
            };
        }
    }
}
