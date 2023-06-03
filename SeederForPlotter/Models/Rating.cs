using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeederForPlotter.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string? Rate { get; set; }
        public static string[] GetArrayRating()
        {
            return new string[5]
            {
                "0+",
                "6+",
                "12+",
                "16+",
                "18+",
            };
        }
    }
}
