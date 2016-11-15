using HomeCrud.Entities;
using System.Data.Entity;

namespace HomeCrud.Test.Specs
{
    public class DataBaseContext : DbContext
    {
        public IDbSet<Home> Homes { get; }
        public IDbSet<Person> Persons { get; }
    }
}
