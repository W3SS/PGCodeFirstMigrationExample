namespace PGCodeFirst.Services.Migrations
{
    using DbModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //    internal sealed class Configuration : DbMigrationsConfiguration<PGCodeFirst.Services.DbModels.MyDbContext>
    public sealed class Configuration : DbMigrationsConfiguration<PGCodeFirst.Services.DbModels.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }
               
        // context yaratildiginda bir kere calistiriliyor.
        // Eger db'de her daim bulunsun istediginiz degerler 
        // var ise, bunlari burada tanimlayabilirsiniz.
        // (Ben bu tur isleri servislerimin init metodlarina 
        // yazip buradan cagirarak yapiyorum.)
        protected override void Seed(MyDbContext context)
        {           
            context.Cities.AddOrUpdate(P => P.Name,
                new City { Name = "İstanbul" },
                new City { Name = "Ankara" },
                new City { Name = "İzmir" },
                new City { Name = "Eskişehir" }
            );

            context.SaveChanges();

            context.Interests.AddOrUpdate(P => P.Name,
                new Interest { Name = "Golf" },
                new Interest { Name = "Seramik" },
                new Interest { Name = "Dans" }
            );
            context.SaveChanges();


            // test kullanicisi var mi diye bakalim.
            var testUserNick = "TestUser";
            if(context.Users.Any(x=>x.Nick == testUserNick))
            {
                return;
            }

            // olusturulacak ilk kullanici kaydi icin ilk sehri secelim
            var city = context.Cities.First();

            // olusturulacak ilk kullanici kaydi icin iki ilgi alani secelim.
            var interests = context.Interests.Take(2).ToList();

            var user = new User();
            user.City = city;                      
            foreach (var interest in interests)
            {
                user.Interests.Add(interest);
            }
            context.Users.Add(user);
            context.SaveChanges();

        }
    }
}
