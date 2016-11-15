﻿namespace HomeCrud.Entities
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Identification { get; set; }

        public virtual Home Home { get; set; }
    }
}