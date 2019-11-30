using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Sky_TNT.Models
{
    public class DataContext:DbContext
    {
        public virtual DbSet<Images> img { get; set; }
        public virtual DbSet<GroupImages> grimg { get; set; }
        public DataContext():base("DbImages")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}