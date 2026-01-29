using GoldAlert.Domain.Alerts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldAlert.Infrastructure.Persistence.Configurations
{
    public class PriceAlertConfiguration : IEntityTypeConfiguration<PriceAlert>
    {
        public void Configure(EntityTypeBuilder<PriceAlert> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TargetPrice)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.HasIndex(x => x.Status);
        }
    }
}
