﻿using Core.Entities;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        //Users-->Id,FirstName,LastName,Email,Password
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
