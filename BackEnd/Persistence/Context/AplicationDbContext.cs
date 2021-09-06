using AlvaroFacturacionApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlvaroFacturacionApi.Persistence.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Products> Products { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
