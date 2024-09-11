using static ConsoleApp1.Services.MyService;

namespace ConsoleApp1.Seed;

public static class DBContextSeedData
{

  public static void EnsureSeedData(this DBContext context)
  {
    Console.WriteLine("remove existing database!");
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    Console.WriteLine("Done");
    Console.ReadKey();
  }


}