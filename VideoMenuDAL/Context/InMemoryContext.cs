using System;
using Microsoft.EntityFrameworkCore;
using VideoMenuEntity;

namespace VideoMenuDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>()
                .UseInMemoryDatabase("TheDB").Options;
        //Options we want in memory

        public InMemoryContext() : base(options)
        {

        }

        public DbSet<Video> videos { get; set; }
    }
}
