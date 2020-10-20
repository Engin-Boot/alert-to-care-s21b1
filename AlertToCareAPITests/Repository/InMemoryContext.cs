using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DbContext = AlertToCareAPI.Models.AppDbContext;

namespace AlertToCareAPITests.Repository
{
    public class InMemoryContext : IDisposable
    {
        protected readonly DbContext Context;

        protected InMemoryContext()
        {
            var option = new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase(
                databaseName: Guid.NewGuid().ToString()).Options;
            Context = new DbContext(option);
            Context.Database.EnsureCreated();
            InitializeDatabase(Context);

        }

        private void InitializeDatabase(DbContext context)
        {
            
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
