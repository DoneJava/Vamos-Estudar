using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VamosEstudar.Models;

namespace VamosEstudar.Data
{
    public class VamosEstudarContext : DbContext
    {
        public VamosEstudarContext(DbContextOptions<VamosEstudarContext> options)
            : base(options) { }

        public DbSet<Estudante> Estudante { get; set; } = default!;
    }
}
