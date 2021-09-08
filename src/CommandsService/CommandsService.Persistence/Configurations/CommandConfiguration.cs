using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommandsService.Persistence.Models;

namespace CommandsService.Persistence.Configurations
{
    public class CommandConfiguration : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder
                .HasOne(x => x.Platform)
                .WithMany(x => x.Commands)
                .HasForeignKey(x => x.PlatformId);
        }
    }
}
