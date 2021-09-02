using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatformService.Persistence.Models;

namespace PlatformService.Persistence.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder
                .Property(user => user.Name)
                .IsRequired(true);

            builder
                .Property(user => user.Publisher)
                .IsRequired(true);
        }
    }
}
