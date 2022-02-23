using Deneme1.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1.Data.Configuration
{
    public class PersonelConfiguration : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.HasKey(x => x.Id); ///Id primary key olsun
            builder.Property(x => x.Id).UseIdentityColumn(); ///1er 1er artsın
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); /// Name gerekli olsun ve maks 50 karakter.
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PersonelNumber).IsRequired().HasMaxLength(12);

            builder.ToTable("Personel");
        }
    }
}
