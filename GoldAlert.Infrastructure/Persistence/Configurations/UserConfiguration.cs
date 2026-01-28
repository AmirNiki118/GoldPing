using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Mobile)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.HasIndex(x => x.Mobile)
                   .IsUnique();
        }
    }
}
