using Domain.Eshop.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Eshop.Models.Product;
using Domain.Eshop.Models.Feature;
using Domain.Eshop.Models.Order;

namespace Infra.Data.Eshop.Context
{
    public class EshopContext:DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> Option) :base(Option) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().HasQueryFilter(t=>t.IsDelete==false);
        }

        #region DB Set

        #region User

        public DbSet<User> Users { get; set; }

        #endregion


        #region Role
        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRole { get; set; }
        #endregion


        #region  Product

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Product { get; set; }


        public DbSet<ProductGallery> ProductGallery { get; set; }

        public DbSet<ProductColor> ProductColor { get; set; }

        public DbSet<ProductComment> ProductComment { get; set; }

        #endregion


        #region Feature

        public DbSet<Feature> Features { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        #endregion
        

        #region Permissions

        public DbSet<PermissionRole> PermissionRoles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        #endregion


        #region Order

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<ProdcutColorOrderDetail> OrderDetailProductColor { get; set; }

        #endregion

        #endregion
    }
}
