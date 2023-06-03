using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeederForPlotter.Models
{
    public class Access_Modificator
    {
        public int Id { get; set; }
        public string? Modificator { get; set; }

        public static string[] GetArrayModificators()
        {
            return new string[2]
            {
                "Публично",
                "Приватно",
            };
        }
    }
}
