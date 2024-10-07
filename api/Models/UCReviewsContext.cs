namespace api.Models;
using Microsoft.EntityFrameworkCore;

public class UCReviewsContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Dorm> Dorm { get; set; }
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

        builder.Entity<Dorm>()
        .HasMany(b => b.Reviews)
        .WithOne(r => r.Dorm)
        .HasForeignKey(r => r.DormId);

        builder.Entity<Dorm>()
        .HasData(
        new Dorm
        {
            Id = 1,
            Name = "Calhoun Hall",
            Style = "Traditional",
            Cost = "$",
            Description = "Located in the heart of Clifton Heights, Calhoun Hall is known for its welcoming atmosphere and scenic views. Its community areas and study floor make it the perfect place to meet neighbors, cultivate friendships, and get involved in the UC community! The proximity to off- and on-campus dining options, as well as entertainment on Calhoun Street makes it an exciting and classic option when it comes to choosing where to live.",
            AverageRating = 3m,
            NameQueryParameter = "Calhoun"
        },
        new Dorm
        {
            Id = 2,
            Name = "CRC",
            Style = "Suite",
            Cost = "$$$",
            Description = "Campus Recreation Center Hall is perfect for students that desire productivity and focus in their day-to-day life. It is located on MainStreet connected to the Rec Center and CenterCourt dining hall, making it the perfect environment for motivation.",
            AverageRating = 4m,
            NameQueryParameter = "CRC"
        },
        new Dorm
        {
            Id = 3,
            Name = "Dabney Hall",
            Style = "Traditional",
            Cost = "$",
            Description = "This newly renovated hall fosters some of the strongest community on campus and puts you at the center of so much activity. Sitting in the middle of campus and just a short walk from the sprawling Sigma Sigma Commons.",
            AverageRating = 2.9m,
            NameQueryParameter = "Dabney"
        },
        new Dorm
        {
            Id = 4,
            Name = "Daniels Hall",
            Style = "Traditional",
            Cost = "$",
            Description = "Daniels Hall most likely matches what comes to mind when you think of a college residence hall. Its traditional-style structure establishes a welcoming and very social atmosphere on every floor.",
            AverageRating = 3m,
            NameQueryParameter = "Daniels"
        },
        new Dorm
        {
            Id = 5,
            Name = "Marian Spencer",
            Style = "Junior Suite",
            Cost = "$$",
            Description = "UC’s newest addition to University Housing and is a wonderful place for students to live. Its unique architecture allows for suite-style rooms.",
            AverageRating = 4.5m,
            NameQueryParameter = "Marian_Spencer"
        },
        new Dorm
        {
            Id = 6,
            Name = "Morgens Hall",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "Renovated in 2013, Morgens Hall was built as one of the Three Sisters and is now a state-of-the-art building with many awards for its eco-friendly design.",
            AverageRating = 0m,
            NameQueryParameter = "Morgens"
        },
        new Dorm
        {
            Id = 7,
            Name = "Schneider Hall",
            Style = "Suite",
            Cost = "$$$",
            Description = "Schneider Hall is in a wonderful part of eastern main campus along Jefferson Avenue, and is close to multiple dining centers, shops, and restaurants.",
            AverageRating = 0m,
            NameQueryParameter = "Schneider"
        },
        new Dorm
        {
            Id = 8,
            Name = "Scioto Hall",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "Located close to multiple dining centers, Scioto Hall provides a spacious environment with suite-style living and plenty of community spaces.",
            AverageRating = 0m,
            NameQueryParameter = "Scioto"
        },
        new Dorm
        {
            Id = 9,
            Name = "Siddall Hall",
            Style = "Traditional",
            Cost = "$",
            Description = "Siddall Hall includes the CCM themed community and is known for its communal activities such as ping pong tournaments and late-night ice cream parties.",
            AverageRating = 0m,
            NameQueryParameter = "Siddall"
        },
        new Dorm
        {
            Id = 10,
            Name = "The Deacon",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "One of UC’s newest off-campus housing communities, The Deacon offers distinctive amenities such as a movie theater and arcade.",
            AverageRating = 0m,
            NameQueryParameter = "Deacon"
        },
        new Dorm
        {
            Id = 11,
            Name = "The Eden",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "Newly constructed apartments just three blocks from campus, with floor plans and amenities ideal for building community among residents.",
            AverageRating = 0m,
            NameQueryParameter = "Eden"
        },
        new Dorm
        {
            Id = 12,
            Name = "Turner Hall",
            Style = "Suite",
            Cost = "$$$",
            Description = "Turner Hall is home to multiple Living-Learning Communities and has ADA accessible accommodations available.",
            AverageRating = 0m,
            NameQueryParameter = "Turner"
        },
        new Dorm
        {
            Id = 13,
            Name = "University Edge",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "University Edge apartments provide near-campus residency options with a sprawling courtyard and proximity to the Cincinnati Zoo.",
            AverageRating = 3.5m,
            NameQueryParameter = "Edge"
        },
        new Dorm
        {
            Id = 14,
            Name = "UPA",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "University Park Apartments offer students an off-campus lifestyle with all the benefits of on-campus living, above many restaurants and shops.",
            AverageRating = 1m,
            NameQueryParameter = "UPA"
        },
        new Dorm
        {
            Id = 15,
            Name = "U Square",
            Style = "Apartment",
            Cost = "$$$$",
            Description = "Located on Calhoun Street, U Square provides apartment-style living with a relaxing and independent lifestyle while offering convenience to businesses.",
            AverageRating = 3.8m,
            NameQueryParameter = "USquare"
        }
        );
        base.OnModelCreating(builder);
    }
}