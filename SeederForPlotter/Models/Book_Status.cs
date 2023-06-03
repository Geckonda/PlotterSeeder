using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeederForPlotter.Models
{
    public class Book_Status
    {
        public int Id { get; set; }
        public string? Status { get; set; }

        public static string[] GetArrayStatuses()
        {
            return new string[4]
            {
                "В процессе",
                "Завершен",
                "Заморожен",
                "Заброшен",
            };
        }
    }
}
