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
    public class TVSerieConfiguration : IEntityTypeConfiguration<TVSerie>
    {
        public void Configure(EntityTypeBuilder<TVSerie> TVSerie)
        {
            TVSerie.HasKey(_ => _.Id);

            TVSerie.ToTable("TVSerie");

            TVSerie.Property(_ => _.Title).IsRequired();
        }
    }
}
