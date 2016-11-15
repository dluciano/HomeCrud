using System;

namespace HomeCrud.Test.Specs
{
    public class CreateHomeRequest : IToEntity<Home>
    {
        public Home ToEntity() =>
            new Home() { };
    }
}