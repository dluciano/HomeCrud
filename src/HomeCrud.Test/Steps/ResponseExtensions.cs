using System;
using System.Collections.Generic;
using System.Linq;
using HomeCrud.Test.Specs;

namespace HomeCrud.Test.Steps
{
    public static class ResponseExtensions
    {
        public static IEnumerable<HomeRowResponse> AsRowCollection(this IReadRepository<Home> _homes) =>
            _homes
            .AsEnumerable()
            .Select(h => new HomeRowResponse.Factory().Create(h));

        public static IEnumerable<PersonListRowResponse> AsRow(this IReadRepository<Person> _people) =>
            _people.AsEnumerable().Select(p => new PersonListRowResponse.Factory().Create(p));
    }
}
