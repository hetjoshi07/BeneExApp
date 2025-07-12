using BeneExApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BeneExApp.Data
{
    public class BeneExAppContext : DbContext
    {
        public BeneExAppContext(DbContextOptions<BeneExAppContext> options) : base(options)
        {
        }

        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
    }
}