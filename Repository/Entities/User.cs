﻿using System.Collections.Generic;

namespace Repository.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
