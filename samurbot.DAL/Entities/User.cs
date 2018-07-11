using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samurbot.DAL.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public int Points { get; set; }
        public int Credits { get; set; }
        public TimeSpan TempTime { get; set; }

    }
}
