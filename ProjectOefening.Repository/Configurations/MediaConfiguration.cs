using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectOefening.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOefening.Repository.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> media)
        {
            media.HasKey(_ => _.Id);

            media.ToTable("media");

            media.Property(_ => _.Title).IsRequired();

            //media.HasMany(_ => _.Reviews).WithOne(_ => _.MediaItem).HasForeignKey(_ => _.MediaId);
        }
    }
}
