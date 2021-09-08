using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CommandsService.Persistence.Models;

namespace PlatformService.Persistence.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            
        }
    }
}
