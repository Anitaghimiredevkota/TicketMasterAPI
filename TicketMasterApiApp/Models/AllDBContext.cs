using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TicketMasterApiApp.Models
{
    public class AllDBContext : DbContext
    {
        public AllDBContext() : 
            base("DefaultConnection")
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }

    }
}


 