using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using samurbot.DAL.Entities;

namespace samurbot.DAL.EF
{
    public class BotContext: DbContext
    {
        public BotContext() : base("Db") {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }
        public DbSet<User> Users { get; set; }
    }
}
