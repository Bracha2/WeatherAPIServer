using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Models;

public partial class dbContxt : DbContext
{
    public dbContxt()
    {
    }

    public dbContxt(DbContextOptions<dbContxt> options)
        : base(options)
    {
    }

    public virtual DbSet<Favory> Favories { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<WeatherByCity> WeatherByCities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect /*potentially*/ sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= (LocalDB)\\MSSQLLocalDB;Database= C:\\Users\\LENOVO\\Documents\\DB.mdf;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favory>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK__Favories__DFD83CAE6092709D");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("key");
            entity.Property(e => e.LocalizName)
                .HasMaxLength(50)
                .HasColumnName("localizName");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK__Table__DFD83CAE99122337");

            entity.ToTable("Table");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("key");
            entity.Property(e => e.LocalizedName)
                .HasMaxLength(50)
                .HasColumnName("localizedName");
            entity.Property(e => e.Weather).HasColumnName("weather");
        });

        modelBuilder.Entity<WeatherByCity>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK__WeatherB__DFD83CAE2A2ACB9C");

            entity.ToTable("WeatherByCity");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("key");
            entity.Property(e => e.Weather).HasColumnName("weather");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
