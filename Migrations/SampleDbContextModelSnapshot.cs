﻿// <auto-generated />
using EFCoreIssue33591;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreIssue33591.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    partial class SampleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreIssue33591.Entities.TransportBase", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("base", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("EFCoreIssue33591.Entities.Car", b =>
                {
                    b.HasBaseType("EFCoreIssue33591.Entities.TransportBase");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("model");

                    b.ToTable("car", (string)null);
                });

            modelBuilder.Entity("EFCoreIssue33591.Entities.Car", b =>
                {
                    b.HasOne("EFCoreIssue33591.Entities.TransportBase", null)
                        .WithOne()
                        .HasForeignKey("EFCoreIssue33591.Entities.Car", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fK_car_base_id");

                    b.OwnsOne("EFCoreIssue33591.Entities.Motor", "Motor", b1 =>
                        {
                            b1.Property<long>("CarId")
                                .HasColumnType("bigint")
                                .HasColumnName("id");

                            b1.Property<int>("Ccm")
                                .HasColumnType("int")
                                .HasColumnName("motor_Ccm");

                            b1.Property<string>("FuelType")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("motor_FuelType");

                            b1.Property<int>("Power")
                                .HasColumnType("int")
                                .HasColumnName("motor_Power");

                            b1.HasKey("CarId");

                            b1.ToTable("car");

                            b1.WithOwner()
                                .HasForeignKey("CarId")
                                .HasConstraintName("fK_car_car_id");
                        });

                    b.Navigation("Motor")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
