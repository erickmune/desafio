using DesafioMinhaVida.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioMinhaVida.DAO
{
    public class EntitiesContext : DbContext
    {
        public DbSet<ElectricGuitar> ElectricGuitars { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElectricGuitar>().HasKey(e => e.Id);            
        }
    }
}
