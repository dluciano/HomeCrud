using HomeCrud.Entities;
using System.Data.Entity;

namespace HomeCrud.DA.EntityFramework
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("HomeConnectionString")
        {

        }

        public IDbSet<Home> Homes => Set<Home>();
        public IDbSet<Person> Persons => Set<Person>();
    }
}