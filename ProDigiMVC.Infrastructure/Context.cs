using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProDigiMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Infrastructure
{
    public class Context : IdentityDbContext 
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContactInformation> CustomerContactInformation { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderTag> OrderTag { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // one to one
            builder.Entity<Customer>()
                .HasOne(a => a.CustomerContactInformation)
                .WithOne(b => b.Customer)
                .HasForeignKey<CustomerContactInformation>(e => e.CustomerRef);
            //==============
            // many to many
            builder.Entity<OrderTag>()
                .HasKey(ot => new { ot.OrderId, ot.TagId });

            builder.Entity<OrderTag>()
                .HasOne<Order>(ot => ot.Order)
                .WithMany(o => o.OrderTags)
                .HasForeignKey(ot => ot.OrderId);

            builder.Entity<OrderTag>()
                .HasOne<Tag>(ot => ot.Tag)
                .WithMany(t => t.OrderTags)
                .HasForeignKey(ot => ot.TagId);
            //===========================
        }
    }
}
