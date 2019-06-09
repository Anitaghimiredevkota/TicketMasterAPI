using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketMasterApiApp.Models
{
    public class UserFavoroiteDBDAL
    {
        private readonly static TicketMasterApiAppDBEntities db = new TicketMasterApiAppDBEntities();

        public static IEnumerable<UserFavorite> GetUserFavorite(string id)
        {
            return db.UserFavorites.Where(u => u.UserId == id);
        }

        public static bool AddUserFavorite(UserFavorite fav)
        {
            try
            {
                db.UserFavorites.Add(fav);
                db.SaveChanges();
            }catch(Exception)
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