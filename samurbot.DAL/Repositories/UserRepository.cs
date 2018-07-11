using samurbot.DAL.EF;
using samurbot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace samurbot.DAL.Repositories
{
     public class UserRepository
    {
        private BotContext db = new BotContext();
        
        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public void Create (User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update (User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete (int id)
        {
            User item = db.Users.Find(id);
            if (item != null)
            {
                db.Users.Remove(item);
                db.SaveChanges();
            }
        }

    }
}
