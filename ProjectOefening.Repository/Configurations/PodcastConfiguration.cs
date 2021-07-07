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
    public class PodcastConfiguration : IEntityTypeConfiguration<Podcast>
    {
        public void Configure(EntityTypeBuilder<Podcast> podcast)
        {
            podcast.HasKey(_ => _.Id);

            podcast.ToTable("podcast");

            podcast.Property(_ => _.Title).IsRequired();
        }
    }
}
