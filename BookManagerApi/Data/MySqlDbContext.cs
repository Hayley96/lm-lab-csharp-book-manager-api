using Microsoft.EntityFrameworkCore;

namespace BookManagerApi.Data
{
    public class MySqlDbContext : ModelsContext
    {
        public MySqlDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MyContextDb");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}