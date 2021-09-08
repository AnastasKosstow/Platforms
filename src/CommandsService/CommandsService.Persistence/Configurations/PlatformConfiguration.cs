using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommandsService.Persistence.Models;

namespace PlatformService.Persistence.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder
                .HasMany(x => x.Commands)
                .WithOne(x => x.Platform!)
                .HasForeignKey(x => x.PlatformId);
        }
    }
}
