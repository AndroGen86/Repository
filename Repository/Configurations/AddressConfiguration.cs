using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entities;

namespace Repository.Configurations
{
    class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("Address");
            HasKey(x => x.Id);
        }
    }
}
