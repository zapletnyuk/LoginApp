using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LoginApp
{
    class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        { }
        public DbSet<User> Users { get; set; }
        //Added a comment))
        //New comment
    }
}
