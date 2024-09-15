using Domain.Eshop.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Context
{
    public class EshopContext:DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> Option) :base(Option) 
        {
            
        }

        #region DB Set

        #region User

        public DbSet<User> Users { get; set; }

        #endregion


        #endregion
    }
}
