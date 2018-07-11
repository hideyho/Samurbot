using samurbot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samurbot.services
{
    public static class MessageRecieved
    {
        public static User Up(User user)
        {
            if (user.TempTime >= DateTime.Now.TimeOfDay) user.TempTime = DateTime.Now.TimeOfDay;
            user.Points += (int)(DateTime.Now.TimeOfDay - user.TempTime).TotalMinutes;
            user.Points += 5;
            if (user.Points < Convert.ToInt32(Resources.Points.r1))
                user.Role = null;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r2))
                user.Role = Resources.Ranks.r1;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r3))
                user.Role = Resources.Ranks.r2;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r4))
                user.Role = Resources.Ranks.r3;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r5))
                user.Role = Resources.Ranks.r4;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r6))
                user.Role = Resources.Ranks.r5;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r7))
                user.Role = Resources.Ranks.r6;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r8))
                user.Role = Resources.Ranks.r7;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r9))
                user.Role = Resources.Ranks.r8;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r10))
                user.Role = Resources.Ranks.r9;
            else
            if (user.Points < Convert.ToInt32(Resources.Points.r11))
                user.Role = Resources.Ranks.r10;
            else
                user.Role = Resources.Ranks.r11;
            user.TempTime = DateTime.Now.TimeOfDay;
            return user;
        }

    }
}
