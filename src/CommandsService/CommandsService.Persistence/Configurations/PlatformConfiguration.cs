using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommandsService.Persistence.Models;

namespace CommandsService.Persistence.Configurations
{
    public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
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
