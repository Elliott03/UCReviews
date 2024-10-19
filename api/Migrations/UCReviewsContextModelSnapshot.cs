﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Models;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(UCReviewsContext))]
    partial class UCReviewsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Dorm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameQueryParameter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dorm");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = "$",
                            Description = "Located in the heart of Clifton Heights, Calhoun Hall is known for its welcoming atmosphere and scenic views. Its community areas and study floor make it the perfect place to meet neighbors, cultivate friendships, and get involved in the UC community! The proximity to off- and on-campus dining options, as well as entertainment on Calhoun Street makes it an exciting and classic option when it comes to choosing where to live.",
                            Name = "Calhoun Hall",
                            NameQueryParameter = "Calhoun",
                            Style = "Traditional"
                        },
                        new
                        {
                            Id = 2,
                            Cost = "$$$",
                            Description = "Campus Recreation Center Hall is perfect for students that desire productivity and focus in their day-to-day life. It is located on MainStreet connected to the Rec Center and CenterCourt dining hall, making it the perfect environment for motivation.",
                            Name = "CRC",
                            NameQueryParameter = "CRC",
                            Style = "Suite"
                        },
                        new
                        {
                            Id = 3,
                            Cost = "$",
                            Description = "This newly renovated hall fosters some of the strongest community on campus and puts you at the center of so much activity. Sitting in the middle of campus and just a short walk from the sprawling Sigma Sigma Commons.",
                            Name = "Dabney Hall",
                            NameQueryParameter = "Dabney",
                            Style = "Traditional"
                        },
                        new
                        {
                            Id = 4,
                            Cost = "$",
                            Description = "Daniels Hall most likely matches what comes to mind when you think of a college residence hall. Its traditional-style structure establishes a welcoming and very social atmosphere on every floor.",
                            Name = "Daniels Hall",
                            NameQueryParameter = "Daniels",
                            Style = "Traditional"
                        },
                        new
                        {
                            Id = 5,
                            Cost = "$$",
                            Description = "UC’s newest addition to University Housing and is a wonderful place for students to live. Its unique architecture allows for suite-style rooms.",
                            Name = "Marian Spencer",
                            NameQueryParameter = "Marian_Spencer",
                            Style = "Junior Suite"
                        },
                        new
                        {
                            Id = 6,
                            Cost = "$$$$",
                            Description = "Renovated in 2013, Morgens Hall was built as one of the Three Sisters and is now a state-of-the-art building with many awards for its eco-friendly design.",
                            Name = "Morgens Hall",
                            NameQueryParameter = "Morgens",
                            Style = "Apartment"
                        },
                        new
                        {
                            Id = 7,
                            Cost = "$$$",
                            Description = "Schneider Hall is in a wonderful part of eastern main campus along Jefferson Avenue, and is close to multiple dining centers, shops, and restaurants.",
                            Name = "Schneider Hall",
                            NameQueryParameter = "Schneider",
                            Style = "Suite"
                        },
                        new
                        {
                            Id = 8,
                            Cost = "$$$$",
                            Description = "Located close to multiple dining centers, Scioto Hall provides a spacious environment with suite-style living and plenty of community spaces.",
                            Name = "Scioto Hall",
                            NameQueryParameter = "Scioto",
                            Style = "Apartment"
                        },
                        new
                        {
                            Id = 9,
                            Cost = "$",
                            Description = "Siddall Hall includes the CCM themed community and is known for its communal activities such as ping pong tournaments and late-night ice cream parties.",
                            Name = "Siddall Hall",
                            NameQueryParameter = "Siddall",
                            Style = "Traditional"
                        },
                        new
                        {
                            Id = 10,
                            Cost = "$$$$",
                            Description = "One of UC’s newest off-campus housing communities, The Deacon offers distinctive amenities such as a movie theater and arcade.",
                            Name = "The Deacon",
                            NameQueryParameter = "Deacon",
                            Style = "Apartment"
                        },
                        new
                        {
                            Id = 11,
                            Cost = "$$$$",
                            Description = "Newly constructed apartments just three blocks from campus, with floor plans and amenities ideal for building community among residents.",
                            Name = "The Eden",
                            NameQueryParameter = "Eden",
                            Style = "Apartment"
                        },
                        new
                        {
                            Id = 12,
                            Cost = "$$$",
                            Description = "Turner Hall is home to multiple Living-Learning Communities and has ADA accessible accommodations available.",
                            Name = "Turner Hall",
                            NameQueryParameter = "Turner",
                            Style = "Suite"
                        },
                        new
                        {
                            Id = 13,
                            Cost = "$$$$",
                            Description = "University Edge apartments provide near-campus residency options with a sprawling courtyard and proximity to the Cincinnati Zoo.",
                            Name = "University Edge",
                            NameQueryParameter = "Edge",
                            Style = "Apartment"
                        },
                        new
                        {
                            Id = 14,
                            Cost = "$$$$",
                            Description = "University Park Apartments offer students an off-campus lifestyle with all the benefits of on-campus living, above many restaurants and shops.",
                            Name = "UPA",
                            NameQueryParameter = "UPA",
                            Style = "Apartment"
                        },
                        new
                        {
                            Id = 15,
                            Cost = "$$$$",
                            Description = "Located on Calhoun Street, U Square provides apartment-style living with a relaxing and independent lifestyle while offering convenience to businesses.",
                            Name = "U Square",
                            NameQueryParameter = "USquare",
                            Style = "Apartment"
                        });
                });

            modelBuilder.Entity("api.Models.ParkingGarage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Campus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameQueryParameter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PermitRequired")
                        .HasColumnType("bit");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("ParkingGarage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "CCM Blvd, Cincinnati, OH 45219",
                            Campus = "Uptown Campus",
                            Latitude = 39.129894,
                            Longitude = -84.516852,
                            Name = "CCM Garage",
                            NameQueryParameter = "CCM",
                            PermitRequired = false,
                            Slug = "ccm"
                        },
                        new
                        {
                            Id = 2,
                            Address = "230 Calhoun St, Cincinnati, OH 45219",
                            Campus = "Uptown Campus",
                            Latitude = 39.128439,
                            Longitude = -84.516615999999999,
                            Name = "Calhoun Garage",
                            NameQueryParameter = "Calhoun",
                            PermitRequired = false,
                            Slug = "calhoun"
                        },
                        new
                        {
                            Id = 3,
                            Address = "2935 Campus Green Dr, Cincinnati, OH 45221",
                            Campus = "Uptown Campus",
                            Latitude = 39.135716000000002,
                            Longitude = -84.515223000000006,
                            Name = "Campus Green Garage",
                            NameQueryParameter = "Campus_Green",
                            PermitRequired = false,
                            Slug = "campus-green"
                        },
                        new
                        {
                            Id = 4,
                            Address = "CCM Blvd, Cincinnati, OH 45219",
                            Campus = "Uptown Campus",
                            Latitude = 39.134303000000003,
                            Longitude = -84.517270999999994,
                            Name = "Clifton Court Garage",
                            NameQueryParameter = "Clifton_Court",
                            PermitRequired = false,
                            Slug = "clifton-court"
                        },
                        new
                        {
                            Id = 5,
                            Address = "2915 Clifton Ave, Cincinnati, OH 45220",
                            Campus = "Uptown Campus",
                            Latitude = 39.134689999999999,
                            Longitude = -84.520307000000003,
                            Name = "Clifton Lots",
                            NameQueryParameter = "Clifton_Lots",
                            PermitRequired = true,
                            Slug = "clifton-lots"
                        },
                        new
                        {
                            Id = 6,
                            Address = "2529 Scioto Ln, Cincinnati, OH 45219",
                            Campus = "Uptown Campus",
                            Latitude = 39.129001000000002,
                            Longitude = -84.512904000000006,
                            Name = "Corry Garage",
                            NameQueryParameter = "Corry",
                            PermitRequired = false,
                            Slug = "corry"
                        },
                        new
                        {
                            Id = 7,
                            Address = "3080 Exploration Ave, Cincinnati, OH 45206",
                            Campus = "Uptown Campus",
                            Latitude = 39.134089000000003,
                            Longitude = -84.494940999999997,
                            Name = "Digital Futures",
                            NameQueryParameter = "Digital_Futures",
                            PermitRequired = false,
                            Slug = "digital-futures"
                        },
                        new
                        {
                            Id = 8,
                            Address = "2630 Stratford Ave, Cincinnati, OH 45220",
                            Campus = "Uptown Campus",
                            Latitude = 39.130840999999997,
                            Longitude = -84.521377000000001,
                            Name = "Stratford Heights Garage",
                            NameQueryParameter = "Stratford_Heights",
                            PermitRequired = true,
                            Slug = "stratford-heights"
                        },
                        new
                        {
                            Id = 9,
                            Address = "40 W University Ave, Cincinnati, OH 45221",
                            Campus = "Uptown Campus",
                            Latitude = 39.134614999999997,
                            Longitude = -84.510986000000003,
                            Name = "University Avenue Garage",
                            NameQueryParameter = "University_Avenue",
                            PermitRequired = false,
                            Slug = "university-avenue"
                        },
                        new
                        {
                            Id = 10,
                            Address = "200 Varsity Village Drive, Cincinnati, OH 45221",
                            Campus = "Uptown Campus",
                            Latitude = 39.130166000000003,
                            Longitude = -84.515963999999997,
                            Name = "Varsity Village Garage",
                            NameQueryParameter = "Varsity_Village",
                            PermitRequired = false,
                            Slug = "varsity-village"
                        },
                        new
                        {
                            Id = 11,
                            Address = "2913 Woodside Drive, Cincinnati, OH 45219",
                            Campus = "Uptown Campus",
                            Latitude = 39.135024999999999,
                            Longitude = -84.515180000000001,
                            Name = "Woodside Avenue Garage",
                            NameQueryParameter = "Woodside_Avenue",
                            PermitRequired = false,
                            Slug = "woodside-avenue"
                        },
                        new
                        {
                            Id = 12,
                            Address = "3232 Healing Way, Cincinnati, OH 45229",
                            Campus = "Medical Campus",
                            Latitude = 39.138082474177075,
                            Longitude = -84.501192464167943,
                            Name = "Blood Cancer Healing Center",
                            NameQueryParameter = "Blood_Cancer_Healing_Center",
                            PermitRequired = false,
                            Slug = "blood-cancer-healing-center"
                        },
                        new
                        {
                            Id = 13,
                            Address = "3223 Eden Ave, Cincinnati, OH 45220",
                            Campus = "Medical Campus",
                            Latitude = 39.137669000000002,
                            Longitude = -84.505159000000006,
                            Name = "Eden Garage",
                            NameQueryParameter = "Eden",
                            PermitRequired = false,
                            Slug = "eden"
                        },
                        new
                        {
                            Id = 14,
                            Address = "151 Goodman Dr, Cincinnati, OH 45219",
                            Campus = "Medical Campus",
                            Latitude = 39.138082474177075,
                            Longitude = -84.501192464167943,
                            Name = "Kingsgate Garage",
                            NameQueryParameter = "Kingsgate",
                            PermitRequired = false,
                            Slug = "kingsgate"
                        });
                });

            modelBuilder.Entity("api.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DormId")
                        .HasColumnType("int");

                    b.Property<int?>("ParkingGarageId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StarRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DormId");

                    b.HasIndex("ParkingGarageId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PasswordExpiration")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("api.Models.Review", b =>
                {
                    b.HasOne("api.Models.Dorm", "Dorm")
                        .WithMany("Reviews")
                        .HasForeignKey("DormId");

                    b.HasOne("api.Models.ParkingGarage", "ParkingGarage")
                        .WithMany("Reviews")
                        .HasForeignKey("ParkingGarageId");

                    b.HasOne("api.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dorm");

                    b.Navigation("ParkingGarage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Dorm", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("api.Models.ParkingGarage", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
