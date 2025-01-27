using Microsoft.EntityFrameworkCore;
using System;

namespace Backend
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherForecast> forecast { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

    }
}
