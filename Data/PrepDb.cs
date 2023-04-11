using PlatformService.Models;

namespace PlatformService.Data; 

public static class PrepDb {
  public static void PreparePopulation(IApplicationBuilder app) {
    using (var serviceScope = app.ApplicationServices.CreateScope()) {
      SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }
  }

  private static void SeedData(AppDbContext context) {
    if (context.Platforms.Any() != false) {
      Console.WriteLine("We already have data in the database. Skipping seeding.");
      return;
    }

    Console.WriteLine("We are seeding data...");

    context.Platforms.AddRange(
      new Platform { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
      new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
      new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" });

    context.SaveChanges();
  }
}