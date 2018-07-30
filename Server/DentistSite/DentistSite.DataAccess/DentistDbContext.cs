using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistSite.DataAccess.EntityFramework;
using DentistSite.Domain.Entities;

namespace DentistSite.DataAccess
{
  public partial class DentistDbContext : DataContext
  {
    protected override string DefaultSchema { get { return "dbo"; } }

    public DentistDbContext()
        : base("name=DentistDb")
    {
    }

    public DentistDbContext(string connectionString)
        : base(connectionString)
    {

    }

    /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      Database.SetInitializer<FarmtoolDbContext>(null);
     

      base.OnModelCreating(modelBuilder);


    }*/

    public DbSet<Doctor> Doctor { get; set; }
  }
}
