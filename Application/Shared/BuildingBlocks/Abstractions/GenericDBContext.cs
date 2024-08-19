using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Abstractions
{
    public class GenericContext<T> : DbContext where T : class
    {
        public DbSet<T> Items { get; set; } = default!;
    }
}
