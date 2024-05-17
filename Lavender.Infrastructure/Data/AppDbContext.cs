using Lavender.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lavender.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public AppDbContext()
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Design> Design { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Consuming> Consuming { get; set; }
        public  DbSet<Accessory> Accessory { get; set; }
        public DbSet<DesignAccessory> DesignAccessory { get; set; }
        public DbSet<DesignImage> DesignImage {  get; set; }
        public DbSet<DesigningSection> DesigningSection { get; set; }
        public DbSet<FabricDesign> FabricDesign { get; set; }
        public DbSet<FabricType> FabricType { get; set; }
        public DbSet<Factory> Factory { get; set; }
        public DbSet<InspirationImage> InspirationImage { get; set;}
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemSize> ItemSize { get; set; }
        public DbSet<ItemSizeWithColor> ItemSizeWithColor { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<LineType> LineType { get; set; }
        public DbSet<MakerSection> MakertSection { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PatternMaker> PatternMaker { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ProductionEmp> ProductionEmp { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<SItemType> SItemType { get; set; }
        public DbSet<StoreItem> StoreItem { get; set; }
        public DbSet<SType> SType { get; set; }
        public DbSet<SewingMachine> SewingMachine { get; set; }
        public DbSet<ModelName> ModelName { get; set; }
        public DbSet<DailyProduction> DailyProduction { get; set; }
        public DbSet<Step> Step { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);
        }


    }
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }
}
