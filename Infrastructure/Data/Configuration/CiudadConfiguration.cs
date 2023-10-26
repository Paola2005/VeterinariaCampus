using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastuctura.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("Ciudad");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id);

        builder.Property(p=>p.NombreCiudad)
        .HasMaxLength(50);

        builder.HasOne(p=>p.Departamentos)
        .WithMany(p=>p.Ciudades)
        .HasForeignKey(p=>p.IdDepartamento);

        builder.HasOne(p=>p.Departamentos)
        .WithMany(p=>p.Ciudades)
        .HasForeignKey(p=>p.IdDepartamento);


    }


}