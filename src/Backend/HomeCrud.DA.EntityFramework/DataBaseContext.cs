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
        public IDbSet<Home> Homes { get; }
        public IDbSet<Person> Persons { get; }
    }
}
