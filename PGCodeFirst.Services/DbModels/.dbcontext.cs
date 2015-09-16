using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PGCodeFirst.Services.DbModels
{
    public class MyDbContext : DbContext
    {

        // buradaki "myConnectionString", web.config'de 
        // tanimladiginiz connectionstring'in adi
        public MyDbContext()
            : base("myConnectionString")
        {

        }

        // her entity icin bir DbSet tanimliyoruz.
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // postgresql'de table'lar schema'larin altinda tanimlanir.
            // tercih edilen şemamız default olan "public"
            modelBuilder.HasDefaultSchema("public");

            // çoğul tablo ismi kullanmayı kaldırdık. 
            // misal User'a gidip Users tablosu değil User tablosu açacak.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // (many-to-many)
            modelBuilder.Entity<User>()
               // bir kullanicinin birden fazla ilgi alani olabilir, 
               .HasMany(e => e.Interests)
               // bir ilgi alaninin birden fazla kullanicisi olabilir
               .WithMany(e => e.Users)      
               .Map(
                   m =>
                   {
                       //'UserInterests' adinda bir tablo ac
                       m.ToTable("UserInterests");
                       // userid'yi UserId adli kolona koy
                       m.MapLeftKey("UserId");
                       // interestid'yi InterestId adli kolona koy 
                       m.MapRightKey("InterestId");    
                   }
                );
        }
    }
}

