namespace BaseToCodeExample.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PizzaModelNew : DbContext
    {
        public PizzaModelNew()
            : base("name=PizzaModelNew")
        {
        }

        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeItems> RecipeItems { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.RecipeItems)
                .WithRequired(e => e.Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Table)
                .WithRequired(e => e.Pizza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recipe>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Recipe>()
                .HasOptional(e => e.Pizza)
                .WithRequired(e => e.Recipe);

            modelBuilder.Entity<Recipe>()
                .HasMany(e => e.RecipeItems)
                .WithRequired(e => e.Recipe)
                .WillCascadeOnDelete(false);
        }
    }
}
