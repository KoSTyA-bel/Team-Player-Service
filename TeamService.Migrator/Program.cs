using Microsoft.EntityFrameworkCore;
using TeamService.DataAccess.Contexts;

string connection = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new ArgumentNullException("Need enviroment variable CONNECTION_STRING");
var optionsBuilder = new DbContextOptionsBuilder<TeamContext>();
optionsBuilder.UseNpgsql(connection);

var context = new TeamContext(optionsBuilder.Options);

await context.Database.MigrateAsync();

Console.WriteLine("Migration was succesful.");