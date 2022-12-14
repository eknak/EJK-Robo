// <auto-generated />
using System;
using EJK.Licitacao.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EJK.Licitacao.Data.Migrations
{
    [DbContext(typeof(PregaoContext))]
    partial class PregaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClientePlataforma", b =>
                {
                    b.Property<int>("ClientesId")
                        .HasColumnType("int");

                    b.Property<int>("PlataformasId")
                        .HasColumnType("int");

                    b.HasKey("ClientesId", "PlataformasId");

                    b.HasIndex("PlataformasId");

                    b.ToTable("ClientePlataforma");
                });

            modelBuilder.Entity("EJK.Shared.Models.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("EJK.Shared.Models.Entities.Plataforma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Plataforma");
                });

            modelBuilder.Entity("EJK.Shared.Models.Entities.Pregao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlataformaId");

                    b.ToTable("Pregao");
                });

            modelBuilder.Entity("EJK.Shared.Models.Mensagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("ClientePlataforma", b =>
                {
                    b.HasOne("EJK.Shared.Models.Entities.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EJK.Shared.Models.Entities.Plataforma", null)
                        .WithMany()
                        .HasForeignKey("PlataformasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EJK.Shared.Models.Entities.Plataforma", b =>
                {
                    b.HasOne("EJK.Shared.Models.Entities.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("EJK.Shared.Models.Entities.Pregao", b =>
                {
                    b.HasOne("EJK.Shared.Models.Entities.Plataforma", "Plataforma")
                        .WithMany()
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plataforma");
                });
#pragma warning restore 612, 618
        }
    }
}
