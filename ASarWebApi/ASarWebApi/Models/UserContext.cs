using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASarWebApi
{
    public class UserContext:DbContext
    {
        public UserContext()
            :base("DefaultConnection")
        {

        }
        public DbSet<UserModel> Users { get; set; }
    }
}
