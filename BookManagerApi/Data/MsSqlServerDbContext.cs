using Microsoft.EntityFrameworkCore;

namespace BookManagerApi.Data
{
    public class MsSqlServerDbContext : ModelsContext
    {
        public MsSqlServerDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MyContextDbSQLServer");
            options.UseSqlServer(connectionString!);
        }
    }
}