namespace api.Models;

using Microsoft.EntityFrameworkCore;

public class UCReviewsContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Dorm> Dorm { get; set; }
    public DbSet<ParkingGarage> ParkingGarage { get; set; }

    public UCReviewsContext(DbContextOptions<UCReviewsContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
        .HasMany(u => u.Reviews)
        .WithOne(r => r.User)
        .HasForeignKey(r => r.UserId);

        builder.Entity<Review>()
        .Property(r => r.StarRating)
        .HasPrecision(2, 1);

        builder.Entity<Dorm>()
            .ToTable("Dorm")
            .HasMany(d => d.Reviews)
            .WithOne(r => r.Dorm)
            .HasForeignKey(r => r.DormId)
            .IsRequired(false);

        builder.Entity<ParkingGarage>()
            .ToTable("ParkingGarage")
            .HasMany(p => p.Reviews)
            .WithOne(r => r.ParkingGarage)
            .HasForeignKey(r => r.ParkingGarageId)
            .IsRequired(false);

        builder.Entity<ParkingGarage>()
        .HasIndex(g => g.Slug).IsUnique();

        builder.Entity<Dorm>()
        .HasData(
        new Dorm
        {
            Id = 1,
            Name = "Calhoun Hall",
            Style = "Traditional",
            Cost = "$",
            Description = "Located in the heart of Clifton Heights, Calhoun Hall is known for its welcoming atmosphere and scenic views. Its community areas and study floor make it the perfect place to meet neighbors, cultivate friendships, and get involved in the UC community! The proximity to off- and on-campus dining options, as well as entertainment on Calhoun Street makes it an exciting and classic option when it comes to choosing where to live.",
            NameQueryParameter = "Calhoun"
        },
        new Dorm
        {
            Id = 2,
            Name = "CRC",
            Style = "Suite",
            Cost = "$$$",
            Description = "Campus Recreation Center Hall is perfect for students that desire productivity and focus in their day-to-day life. It is located on MainStreet connected to the Rec Center and CenterCourt dining hall, making it the perfect environment for motivation.",
            NameQueryParameter = "CRC"
        },
        new Dorm
        {
            Id = 3,
            Name = "Dabney Hall",
            Style = "Traditional",
            Cost = "$",
            Description = "This newly renovated hall fosters some of the strongest community on campus and puts you at the center of so much activity. Sitting in the middle of campus and just a short walk from the sprawling Sigma Sigma Commons.",
            NameQueryParameter = "Dabney"
        },
        new Dorm
        {
            Id = 4,
            Name = "Daniels Hall",
            Style = "Traditional",
            Cost = "$",
            Description = "Daniels Hall most likely matches what comes to mind when you think of a college residence hall. Its traditional-style structure establishes a welcoming and very social atmosphere on every floor.",
            NameQueryParameter = "Daniels"
        },
        new Dorm
        {
            Id = 5,
            Name = "Marian Spencer",
            Style = "Junior Suite",
            Cost = "$$",
            Description = "UC’s newest addition to University Housing and is a wonderful place for students to live. Its unique architecture allows for suite-style rooms.",
            NameQueryParameter = "Marian_Spencer"
        },
        new Dorm
        {
            Id = 6,
            Name = "Morgens Hall",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "Renovated in 2013, Morgens Hall was built as one of the Three Sisters and is now a state-of-the-art building with many awards for its eco-friendly design.",
            NameQueryParameter = "Morgens"
        },
        new Dorm
        {
            Id = 7,
            Name = "Schneider Hall",
            Style = "Suite",
            Cost = "$$$",
            Description = "Schneider Hall is in a wonderful part of eastern main campus along Jefferson Avenue, and is close to multiple dining centers, shops, and restaurants.",
            NameQueryParameter = "Schneider"
        },
        new Dorm
        {
            Id = 8,
            Name = "Scioto Hall",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "Located close to multiple dining centers, Scioto Hall provides a spacious environment with suite-style living and plenty of community spaces.",
            NameQueryParameter = "Scioto"
        },
        new Dorm
        {
            Id = 9,
            Name = "Siddall Hall",
            Style = "Traditional",
            Cost = "$",
            Description = "Siddall Hall includes the CCM themed community and is known for its communal activities such as ping pong tournaments and late-night ice cream parties.",
            NameQueryParameter = "Siddall"
        },
        new Dorm
        {
            Id = 10,
            Name = "The Deacon",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "One of UC’s newest off-campus housing communities, The Deacon offers distinctive amenities such as a movie theater and arcade.",
            NameQueryParameter = "Deacon"
        },
        new Dorm
        {
            Id = 11,
            Name = "The Eden",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "Newly constructed apartments just three blocks from campus, with floor plans and amenities ideal for building community among residents.",
            NameQueryParameter = "Eden"
        },
        new Dorm
        {
            Id = 12,
            Name = "Turner Hall",
            Style = "Suite",
            Cost = "$$$",
            Description = "Turner Hall is home to multiple Living-Learning Communities and has ADA accessible accommodations available.",
            NameQueryParameter = "Turner"
        },
        new Dorm
        {
            Id = 13,
            Name = "University Edge",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "University Edge apartments provide near-campus residency options with a sprawling courtyard and proximity to the Cincinnati Zoo.",
            NameQueryParameter = "Edge"
        },
        new Dorm
        {
            Id = 14,
            Name = "UPA",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "University Park Apartments offer students an off-campus lifestyle with all the benefits of on-campus living, above many restaurants and shops.",
            NameQueryParameter = "UPA"
        },
        new Dorm
        {
            Id = 15,
            Name = "U Square",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "Located on Calhoun Street, U Square provides apartment-style living with a relaxing and independent lifestyle while offering convenience to businesses.",
            NameQueryParameter = "USquare"
        }
        );

        var offset = 15;

        builder.Entity<ParkingGarage>()
        .HasData
        (
            new ParkingGarage
            {
                Id = offset + 1,
                Name = "CCM Garage",
                Slug = "ccm",
                NameQueryParameter = "CCM",
                Latitude = 39.129894,
                Longitude = -84.516852,
                Campus = "Uptown Campus",
                Address = "CCM Blvd, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 2,
                Name = "Calhoun Garage",
                Slug = "calhoun",
                NameQueryParameter = "Calhoun",
                Latitude = 39.128439,
                Longitude = -84.516616,
                Campus = "Uptown Campus",
                Address = "230 Calhoun St, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 3,
                Name = "Campus Green Garage",
                Slug = "campus-green",
                NameQueryParameter = "Campus_Green",
                Latitude = 39.135716,
                Longitude = -84.515223,
                Campus = "Uptown Campus",
                Address = "2935 Campus Green Dr, Cincinnati, OH 45221",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 4,
                Name = "Clifton Court Garage",
                Slug = "clifton-court",
                NameQueryParameter = "Clifton_Court",
                Latitude = 39.134303,
                Longitude = -84.517271,
                Campus = "Uptown Campus",
                Address = "CCM Blvd, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 5,
                Name = "Clifton Lots",
                Slug = "clifton-lots",
                NameQueryParameter = "Clifton_Lots",
                Latitude = 39.134690,
                Longitude = -84.520307,
                Campus = "Uptown Campus",
                Address = "2915 Clifton Ave, Cincinnati, OH 45220",
                PermitRequired = true
            },
            new ParkingGarage
            {
                Id = offset + 6,
                Name = "Corry Garage",
                Slug = "corry",
                NameQueryParameter = "Corry",
                Latitude = 39.129001,
                Longitude = -84.512904,
                Campus = "Uptown Campus",
                Address = "2529 Scioto Ln, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 7,
                Name = "Digital Futures",
                Slug = "digital-futures",
                NameQueryParameter = "Digital_Futures",
                Latitude = 39.134089,
                Longitude = -84.494941,
                Campus = "Uptown Campus",
                Address = "3080 Exploration Ave, Cincinnati, OH 45206",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 8,
                Name = "Stratford Heights Garage",
                Slug = "stratford-heights",
                NameQueryParameter = "Stratford_Heights",
                Latitude = 39.130841,
                Longitude = -84.521377,
                Campus = "Uptown Campus",
                Address = "2630 Stratford Ave, Cincinnati, OH 45220",
                PermitRequired = true
            },
            new ParkingGarage
            {
                Id = offset + 9,
                Name = "University Avenue Garage",
                Slug = "university-avenue",
                NameQueryParameter = "University_Avenue",
                Latitude = 39.134615,
                Longitude = -84.510986,
                Campus = "Uptown Campus",
                Address = "40 W University Ave, Cincinnati, OH 45221",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 10,
                Name = "Varsity Village Garage",
                Slug = "varsity-village",
                NameQueryParameter = "Varsity_Village",
                Latitude = 39.130166,
                Longitude = -84.515964,
                Campus = "Uptown Campus",
                Address = "200 Varsity Village Drive, Cincinnati, OH 45221",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 11,
                Name = "Woodside Avenue Garage",
                Slug = "woodside-avenue",
                NameQueryParameter = "Woodside_Avenue",
                Latitude = 39.135025,
                Longitude = -84.515180,
                Campus = "Uptown Campus",
                Address = "2913 Woodside Drive, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 12,
                Name = "Blood Cancer Healing Center",
                Slug = "blood-cancer-healing-center",
                NameQueryParameter = "Blood_Cancer_Healing_Center",
                Latitude = 39.138082474177075,
                Longitude = -84.50119246416794,
                Campus = "Medical Campus",
                Address = "3232 Healing Way, Cincinnati, OH 45229",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 13,
                Name = "Eden Garage",
                Slug = "eden",
                NameQueryParameter = "Eden",
                Latitude = 39.137669,
                Longitude = -84.505159,
                Campus = "Medical Campus",
                Address = "3223 Eden Ave, Cincinnati, OH 45220",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = offset + 14,
                Name = "Kingsgate Garage",
                Slug = "kingsgate",
                NameQueryParameter = "Kingsgate",
                Latitude = 39.138082474177075,
                Longitude = -84.50119246416794,
                Campus = "Medical Campus",
                Address = "151 Goodman Dr, Cincinnati, OH 45219",
                PermitRequired = false
            }
        );


        base.OnModelCreating(builder);
    }
}