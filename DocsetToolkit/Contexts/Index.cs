using System.Data.Entity;
using System.Data.SQLite;
using Toolkit.Models;

namespace Toolkit.Contexts
{
    internal class IndexContext : DbContext
    {
        public static IndexContext Create(string nameOrConnectionString)
        {
            return new IndexContext(nameOrConnectionString);
        }

        public IndexContext(string nameOrConnectionString) : base(new SQLiteConnection(nameOrConnectionString), true)
        {
        }

        public DbSet<Index> SearchIndex { get; set; }
    }
}