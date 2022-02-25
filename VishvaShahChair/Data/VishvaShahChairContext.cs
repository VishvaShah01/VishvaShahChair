using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VishvaShahChair.Models;

namespace VishvaShahChair.Data
{
    public class VishvaShahChairContext : DbContext
    {
        public VishvaShahChairContext (DbContextOptions<VishvaShahChairContext> options)
            : base(options)
        {
        }

        public DbSet<VishvaShahChair.Models.Chair> Chair { get; set; }
    }
}
