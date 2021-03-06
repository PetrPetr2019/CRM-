﻿// <auto-generated />
using System;
using CompanyMailingList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyMailingList.Migrations
{
    [DbContext(typeof(UserInformDBContext))]
    [Migration("20200307221838_x1")]
    partial class x1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyMailingList.Documents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addressees")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CargoPlacement")
                        .HasColumnType("bit");

                    b.Property<bool>("ContentState")
                        .HasColumnType("bit");

                    b.Property<string>("CustomsPost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionCargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Entry")
                        .HasColumnType("bit");

                    b.Property<bool>("Exit")
                        .HasColumnType("bit");

                    b.Property<string>("NotificationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberTC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumberDrive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RadiationControl")
                        .HasColumnType("bit");

                    b.Property<string>("Recipient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientsNNN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sacrifieces")
                        .HasColumnType("bit");

                    b.Property<bool>("TheconditionSeals")
                        .HasColumnType("bit");

                    b.Property<bool>("ThemachineTP")
                        .HasColumnType("bit");

                    b.Property<bool>("TimeEvents")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeTransmissionDocumentsDriver")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Tyre")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("CompanyMailingList.Informations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Dynamic")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeInformation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Informations");
                });
#pragma warning restore 612, 618
        }
    }
}
