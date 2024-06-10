using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConfiguration.Infrastructure.Contextx
{
    public partial class AppDbContexts: DbContext
    {
        public AppDbContexts()
        { 
        }
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options)
        {

        }

    }
}
