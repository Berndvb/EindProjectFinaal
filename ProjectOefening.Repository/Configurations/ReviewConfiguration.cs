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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> review)
        {
            review.HasKey(_ => _.Id);

            review.ToTable("review");

            //review.Property(_ => _.Owner).IsRequired();

            //review.HasOne(_ => _.MediaItem).WithMany(_ => _.Reviews).HasForeignKey(_ => _.MediaId);
        }
    }
}
