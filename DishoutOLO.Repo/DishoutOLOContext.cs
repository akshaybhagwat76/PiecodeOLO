using DishoutOLO.Data;
using Microsoft.EntityFrameworkCore;

namespace DishoutOLO.Repo
{
    public class DishoutOLOContext : DbContext
    {
        public DishoutOLOContext(DbContextOptions<DishoutOLOContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<Article> Articles { get; set; }

        public DbSet<ItemGroups> ItemGroup { get; set; }    
        public DbSet<Customer> Customers { get; set; }  

        public DbSet<Modifier> Modifiers { get; set; }

        public DbSet<ModifierGroup> ModifierGroups { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<MenuAvailabilities> MenuAvailabilities { get; set; }
        public DbSet<Coupen> Coupens { get; set; }

        public DbSet<Roles> Roles { get; set; } 
        public DbSet<Order> Orders { get; set; }

        public DbSet<UserStaff> UserStaffs { get; set; }  
        
        public DbSet<MenuDetails> MenuDetails { get; set; } 
    }
}
