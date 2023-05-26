﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPrimerParcial.Data;

#nullable disable

namespace Test.Migrations
{
    [DbContext(typeof(AeronaveContext))]
    partial class AeronaveContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Aeronave", b =>
                {
                    b.Property<int>("AeronaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoAeronave")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AeronaveId");

                    b.ToTable("Aeronave");
                });

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AeronaveId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DNI")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LegajoVuelo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreInstructor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("InstructorId");

                    b.HasIndex("AeronaveId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Instructor", b =>
                {
                    b.HasOne("ProyectoPrimerParcial.Models.Aeronave", "Aeronave")
                        .WithMany("InstructorList")
                        .HasForeignKey("AeronaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeronave");
                });

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Aeronave", b =>
                {
                    b.Navigation("InstructorList");
                });
#pragma warning restore 612, 618
        }
    }
}