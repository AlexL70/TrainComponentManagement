﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webapi.Infrastructure.Database;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(TrainComponentsDbContext))]
    partial class TrainComponentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityAlwaysColumns(modelBuilder);

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.InventoryPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("SerialNumber");

                    b.HasIndex("BrandId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<int>("RootElementId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("RootElementId");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<int>("ModelElementId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentElementId")
                        .HasColumnType("integer");

                    b.Property<int>("TrainId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId")
                        .IsUnique();

                    b.HasIndex("ModelElementId");

                    b.HasIndex("ParentElementId");

                    b.HasIndex("TrainId");

                    b.ToTable("TrainElements");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponentBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueNumMask")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TypeId");

                    b.ToTable("TrainComponentBrands");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1001L, null, null, null, null, null);

                    b.Property<bool>("CanAssignQuantity")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TrainComponentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CanAssignQuantity = false,
                            IsRoot = true,
                            Name = "Train"
                        },
                        new
                        {
                            Id = 2,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Engine"
                        },
                        new
                        {
                            Id = 3,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Passenger Car"
                        },
                        new
                        {
                            Id = 4,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Freight Car"
                        },
                        new
                        {
                            Id = 5,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Wheel"
                        },
                        new
                        {
                            Id = 6,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Seat"
                        },
                        new
                        {
                            Id = 7,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Window"
                        },
                        new
                        {
                            Id = 8,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Door"
                        },
                        new
                        {
                            Id = 9,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Control Panel"
                        },
                        new
                        {
                            Id = 10,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Light"
                        },
                        new
                        {
                            Id = 11,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Brake"
                        },
                        new
                        {
                            Id = 12,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Bolt"
                        },
                        new
                        {
                            Id = 13,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Nut"
                        },
                        new
                        {
                            Id = 14,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Engine Hood"
                        },
                        new
                        {
                            Id = 15,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Axle"
                        },
                        new
                        {
                            Id = 16,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Piston"
                        },
                        new
                        {
                            Id = 17,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Handrail"
                        },
                        new
                        {
                            Id = 18,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Step"
                        },
                        new
                        {
                            Id = 19,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Roof"
                        },
                        new
                        {
                            Id = 20,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Air Conditioner"
                        },
                        new
                        {
                            Id = 21,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Flooring"
                        },
                        new
                        {
                            Id = 22,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Mirror"
                        },
                        new
                        {
                            Id = 23,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Horn"
                        },
                        new
                        {
                            Id = 24,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Coupler"
                        },
                        new
                        {
                            Id = 25,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Hinge"
                        },
                        new
                        {
                            Id = 26,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Ladder"
                        },
                        new
                        {
                            Id = 27,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Paint"
                        },
                        new
                        {
                            Id = 28,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Decal"
                        },
                        new
                        {
                            Id = 29,
                            CanAssignQuantity = true,
                            IsRoot = false,
                            Name = "Gauge"
                        },
                        new
                        {
                            Id = 30,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Battery"
                        },
                        new
                        {
                            Id = 31,
                            CanAssignQuantity = false,
                            IsRoot = false,
                            Name = "Radiator"
                        });
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponentTypeRelation", b =>
                {
                    b.Property<int>("ParentTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("ChildTypeId")
                        .HasColumnType("integer");

                    b.HasKey("ParentTypeId", "ChildTypeId");

                    b.HasIndex("ChildTypeId");

                    b.ToTable("TrainComponentTypeRelation");

                    b.HasData(
                        new
                        {
                            ParentTypeId = 1,
                            ChildTypeId = 2
                        },
                        new
                        {
                            ParentTypeId = 1,
                            ChildTypeId = 3
                        },
                        new
                        {
                            ParentTypeId = 1,
                            ChildTypeId = 4
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 29
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 29
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 29
                        },
                        new
                        {
                            ParentTypeId = 29,
                            ChildTypeId = 15
                        },
                        new
                        {
                            ParentTypeId = 29,
                            ChildTypeId = 5
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 6
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 6
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 7
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 7
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 8
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 8
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 8
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 9
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 10
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 11
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 11
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 11
                        },
                        new
                        {
                            ParentTypeId = 5,
                            ChildTypeId = 12
                        },
                        new
                        {
                            ParentTypeId = 5,
                            ChildTypeId = 13
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 14
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 16
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 17
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 17
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 17
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 18
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 18
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 19
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 19
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 19
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 20
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 20
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 21
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 21
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 22
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 23
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 24
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 24
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 24
                        },
                        new
                        {
                            ParentTypeId = 8,
                            ChildTypeId = 25
                        },
                        new
                        {
                            ParentTypeId = 7,
                            ChildTypeId = 25
                        },
                        new
                        {
                            ParentTypeId = 24,
                            ChildTypeId = 25
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 26
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 26
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 26
                        },
                        new
                        {
                            ParentTypeId = 19,
                            ChildTypeId = 27
                        },
                        new
                        {
                            ParentTypeId = 21,
                            ChildTypeId = 27
                        },
                        new
                        {
                            ParentTypeId = 8,
                            ChildTypeId = 27
                        },
                        new
                        {
                            ParentTypeId = 7,
                            ChildTypeId = 27
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 28
                        },
                        new
                        {
                            ParentTypeId = 3,
                            ChildTypeId = 28
                        },
                        new
                        {
                            ParentTypeId = 4,
                            ChildTypeId = 28
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 30
                        },
                        new
                        {
                            ParentTypeId = 2,
                            ChildTypeId = 31
                        });
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ParentElementId")
                        .HasColumnType("integer");

                    b.Property<bool>("ReadyForUsing")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentElementId");

                    b.ToTable("TrainModels");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainModelElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId");

                    b.HasIndex("ParentId");

                    b.ToTable("TrainModelElements");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.InventoryPart", b =>
                {
                    b.HasOne("webapi.Infrastructure.Database.Models.TrainComponentBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.Train", b =>
                {
                    b.HasOne("webapi.Infrastructure.Database.Models.TrainModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Infrastructure.Database.Models.TrainComponent", "RootElement")
                        .WithMany()
                        .HasForeignKey("RootElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("RootElement");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponent", b =>
                {
                    b.HasOne("webapi.Infrastructure.Database.Models.InventoryPart", "InventoryElement")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Infrastructure.Database.Models.TrainModelElement", "ModelElement")
                        .WithMany()
                        .HasForeignKey("ModelElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Infrastructure.Database.Models.TrainComponent", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentElementId");

                    b.HasOne("webapi.Infrastructure.Database.Models.Train", "Train")
                        .WithMany()
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InventoryElement");

                    b.Navigation("ModelElement");

                    b.Navigation("Parent");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponentBrand", b =>
                {
                    b.HasOne("webapi.Infrastructure.Database.Models.TrainComponentType", "Type")
                        .WithMany("BrandsAvailable")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponentTypeRelation", b =>
                {
                    b.HasOne("webapi.Infrastructure.Database.Models.TrainComponentType", "ChildType")
                        .WithMany("CanHaveParents")
                        .HasForeignKey("ChildTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("webapi.Infrastructure.Database.Models.TrainComponentType", "ParentType")
                        .WithMany("CanHaveChildren")
                        .HasForeignKey("ParentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChildType");

                    b.Navigation("ParentType");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainModel", b =>
                {
                    b.HasOne("webapi.Infrastructure.Database.Models.TrainModelElement", "ParentElement")
                        .WithMany()
                        .HasForeignKey("ParentElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentElement");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainModelElement", b =>
                {
                    b.HasOne("webapi.Infrastructure.Database.Models.TrainComponentBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Infrastructure.Database.Models.TrainModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Infrastructure.Database.Models.TrainModelElement", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Brand");

                    b.Navigation("Model");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponent", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainComponentType", b =>
                {
                    b.Navigation("BrandsAvailable");

                    b.Navigation("CanHaveChildren");

                    b.Navigation("CanHaveParents");
                });

            modelBuilder.Entity("webapi.Infrastructure.Database.Models.TrainModelElement", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
