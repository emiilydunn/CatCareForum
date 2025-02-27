using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatCareForum.Models;

namespace CatCareForum.Data
{
    public class CatCareForumContext : DbContext
    {
        public CatCareForumContext (DbContextOptions<CatCareForumContext> options)
            : base(options)
        {
        }

        public DbSet<CatCareForum.Models.Discussion> Discussion { get; set; } = default!;
    }
}
