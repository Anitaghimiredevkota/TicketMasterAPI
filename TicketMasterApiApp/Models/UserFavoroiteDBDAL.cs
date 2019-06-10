using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketMasterApiApp.Models
{
    public class UserFavoroiteDBDAL
    {
        private readonly static AllDBContext db = new AllDBContext();

        //public static IEnumerable<UserFavorite> GetUserFavorites(string id)
        //{

        //}

        public static bool DeleteFavorite(string eId, string user)
        {
            try
            {
                UserFavorite f = db.UserFavorites.FirstOrDefault(e => e.EventId == eId && e.UserId == user);
                db.UserFavorites.Remove(f);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                string r = e.Message;
                return false;
            }
            return true;
        }

        public static bool AddUserFavorite(Event ev, string user)
        {
            try
            {
                if (db.Events.FirstOrDefault(e => e.Id == ev.Id) is null)
                {
                    db.Events.Add(ev);
                    db.SaveChanges();
                }
                db.UserFavorites.Add(new UserFavorite { EventId = ev.Id, UserId = user });
                db.SaveChanges();
            }
            catch (Exception)
            {               
                return false;
            }
            return true;
        }

        public static bool RemoveUserFavorite(UserFavorite fav)
        {
            try
            {
                db.UserFavorites.Remove(fav);
                db.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}