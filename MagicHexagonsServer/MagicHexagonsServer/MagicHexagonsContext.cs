using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicHexagonsModel.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicHexagonsServer
{
    public class MagicHexagonsContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MagicHexagonsContext(DbContextOptions<MagicHexagonsContext> options)
            : base(options)
        {
        }
    }
}
