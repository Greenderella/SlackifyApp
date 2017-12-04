using System;
using System.Data.Entity;

namespace SlackifyApp.Models
{
    public class DataBaseConfigure
    {
        public int ID { get; set; }
        public string token { get; set; }
        public string url { get; set; }
        public string endpoint { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<DataBaseConfigure> DB { get; set; }
    }
}