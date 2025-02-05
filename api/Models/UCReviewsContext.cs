namespace api.Models;

using Microsoft.EntityFrameworkCore;

public class UCReviewsContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Dorm> Dorm { get; set; }
    public DbSet<ParkingGarage> ParkingGarage { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<DiningHall> DiningHall { get; set; }
    public DbSet<ReviewSummary> ReviewSummary { get; set; }

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
            .ToTable("Dorm")
            .HasMany(d => d.Reviews)
            .WithOne(r => r.Dorm)
            .HasForeignKey(r => r.DormId)
            .IsRequired(false);

        builder.Entity<Dorm>()
            .HasOne(d => d.ReviewSummary)
            .WithOne(r => r.Dorm)
            .HasForeignKey<ReviewSummary>(rs => rs.DormId)
            .IsRequired(false);

        builder.Entity<ParkingGarage>()
            .ToTable("ParkingGarage")
            .HasMany(p => p.Reviews)
            .WithOne(r => r.ParkingGarage)
            .HasForeignKey(r => r.ParkingGarageId)
            .IsRequired(false);

        builder.Entity<ParkingGarage>()
            .HasOne(p => p.ReviewSummary)
            .WithOne(r => r.ParkingGarage)
            .HasForeignKey<ReviewSummary>(rs => rs.ParkingGarageId)
            .IsRequired(false);

        builder.Entity<ParkingGarage>()
            .HasIndex(g => g.Slug)
            .IsUnique();

        builder.Entity<DiningHall>()
            .HasMany(d => d.Reviews)
            .WithOne(r => r.DiningHall)
            .HasForeignKey(r => r.DiningHallId);

        builder.Entity<DiningHall>()
            .HasOne(d => d.ReviewSummary)
            .WithOne(r => r.DiningHall)
            .HasForeignKey<ReviewSummary>(rs => rs.DiningHallId)
            .IsRequired(false);

        builder.Entity<Course>()
            .ToTable("Course")
            .HasMany(c => c.Reviews)
            .WithOne(r => r.Course)
            .HasForeignKey(r => r.CourseId)
            .IsRequired(false);

        builder.Entity<Course>()
            .HasOne(c => c.ReviewSummary)
            .WithOne(r => r.Course)
            .HasForeignKey<ReviewSummary>(rs => rs.CourseId)
            .IsRequired(false);

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

        builder.Entity<ParkingGarage>()
        .HasData
        (
            new ParkingGarage
            {
                Id = 1,
                Name = "CCM Garage",
                Slug = "ccm",
                Latitude = 39.129894,
                Longitude = -84.516852,
                Campus = "Uptown Campus",
                Address = "CCM Blvd, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 2,
                Name = "Calhoun Garage",
                Slug = "calhoun",
                Latitude = 39.128439,
                Longitude = -84.516616,
                Campus = "Uptown Campus",
                Address = "230 Calhoun St, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 3,
                Name = "Campus Green Garage",
                Slug = "campus-green",
                Latitude = 39.135716,
                Longitude = -84.515223,
                Campus = "Uptown Campus",
                Address = "2935 Campus Green Dr, Cincinnati, OH 45221",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 4,
                Name = "Clifton Court Garage",
                Slug = "clifton-court",
                Latitude = 39.134303,
                Longitude = -84.517271,
                Campus = "Uptown Campus",
                Address = "CCM Blvd, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 5,
                Name = "Clifton Lots",
                Slug = "clifton-lots",
                Latitude = 39.134690,
                Longitude = -84.520307,
                Campus = "Uptown Campus",
                Address = "2915 Clifton Ave, Cincinnati, OH 45220",
                PermitRequired = true
            },
            new ParkingGarage
            {
                Id = 6,
                Name = "Corry Garage",
                Slug = "corry",
                Latitude = 39.129001,
                Longitude = -84.512904,
                Campus = "Uptown Campus",
                Address = "2529 Scioto Ln, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 7,
                Name = "Digital Futures",
                Slug = "digital-futures",
                Latitude = 39.134089,
                Longitude = -84.494941,
                Campus = "Uptown Campus",
                Address = "3080 Exploration Ave, Cincinnati, OH 45206",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 8,
                Name = "Stratford Heights Garage",
                Slug = "stratford-heights",
                Latitude = 39.130841,
                Longitude = -84.521377,
                Campus = "Uptown Campus",
                Address = "2630 Stratford Ave, Cincinnati, OH 45220",
                PermitRequired = true
            },
            new ParkingGarage
            {
                Id = 9,
                Name = "University Avenue Garage",
                Slug = "university-avenue",
                Latitude = 39.134615,
                Longitude = -84.510986,
                Campus = "Uptown Campus",
                Address = "40 W University Ave, Cincinnati, OH 45221",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 10,
                Name = "Varsity Village Garage",
                Slug = "varsity-village",
                Latitude = 39.130166,
                Longitude = -84.515964,
                Campus = "Uptown Campus",
                Address = "200 Varsity Village Drive, Cincinnati, OH 45221",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 11,
                Name = "Woodside Avenue Garage",
                Slug = "woodside-avenue",
                Latitude = 39.135025,
                Longitude = -84.515180,
                Campus = "Uptown Campus",
                Address = "2913 Woodside Drive, Cincinnati, OH 45219",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 12,
                Name = "Blood Cancer Healing Center",
                Slug = "blood-cancer-healing-center",
                Latitude = 39.138082474177075,
                Longitude = -84.50119246416794,
                Campus = "Medical Campus",
                Address = "3232 Healing Way, Cincinnati, OH 45229",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 13,
                Name = "Eden Garage",
                Slug = "eden",
                Latitude = 39.137669,
                Longitude = -84.505159,
                Campus = "Medical Campus",
                Address = "3223 Eden Ave, Cincinnati, OH 45220",
                PermitRequired = false
            },
            new ParkingGarage
            {
                Id = 14,
                Name = "Kingsgate Garage",
                Slug = "kingsgate",
                Latitude = 39.138082474177075,
                Longitude = -84.50119246416794,
                Campus = "Medical Campus",
                Address = "151 Goodman Dr, Cincinnati, OH 45219",
                PermitRequired = false
            }
        );
        builder.Entity<DiningHall>()
        .HasData
        (
            new DiningHall
            {
                Id = 1,
                Name = "Cincy Grill",
                Category = "Retail Dining",
                Description = "Located on the second floor of the Tangeman University Center, Cincy Grill is home to grill favorites such as chicken tenders, smash burgers, loaded tots and much more.",
                IncludedInMealPlan = "Meal Exchange",
                Location = "Cincy Grill - Tangemen University Center, 2701 Bearcat Way",
                NameQueryParameter = "CincyGrill"
            },
            new DiningHall
            {
                Id = 2,
                Name = "Chick-fil-A",
                Category = "Retail Dining",
                Description = "A favorite stop for breakfast, lunch, or dinner, Chick-fil-A offers premium chicken sandwiches, salads, nuggets, waffle fries, and more.",
                IncludedInMealPlan = "No",
                Location = "Chick-Fil-A - Tangeman University Center, 2701 Bearcat Way",
                NameQueryParameter = "ChickFilA"

            },
            new DiningHall
            {
                Id = 3,
                Name = "Teachers Café",
                Category = "Café",
                Description = "Teachers Café offers a wide variety of grab ‘n go sandwiches, salads, fruit cups, parfaits and more. If you need a pick-me-up, we also serve Rooted Grounds coffee.",
                IncludedInMealPlan = "Meal Exchange",
                Location = "Teachers Café, 2610 University Circle",
                NameQueryParameter = "TeachersCafé"
            },
            new DiningHall
            {
                Id = 4,
                Name = "Bearcats Café",
                Category = "Café",
                Description = "Bearcats Café, located in TUC offers both a grab and go style meal or a hot meal to go. \nBABB (Bad-Ass Breakfast Burritos) - Satisfy your early-morning or late-night cravings with burritos packed with premium meats, crispy potatoes, cheese, and eggs, all wrapped in a soft tortilla. Top it off with our addictive sauces for a truly satisfying meal. \nStuffed Sensation - Treat yourself to Otis Spunkmeyer cookies stuffed with irresistible fillings like Oreos® and Reese’s. These decadent cookies are sure to be a hit, whether served fresh or pre-packaged. \nTo the Max Mexican - Build a healthy, flavorful bowl or burrito at To The Max Mexican. Choose from fresh, authentically seasoned ingredients, carefully portioned for a balanced meal. \nAC BBQ - Enjoy rich, flavorful barbecue rooted in Black excellence and community, created by Anthony Anderson and Cedric the Entertainer. AC Barbeque brings people together with its delicious, culturally inspired dishes.",
                IncludedInMealPlan = "Carryout and Limited Seating",
                Location = "Bearcats Café - Tangeman University Center, 2701 Bearcat Way",
                NameQueryParameter = "BearcatsCafé"
            },
            new DiningHall
            {
                Id = 5,
                Name = "CampusView Café",
                Category = "Café",
                Description = "Campus View Café offers a wide variety of grab ‘n go sandwiches, salads, fruit cups, parfaits and more. If you need a pick-me-up, we also serve Rooted Grounds coffee.",
                IncludedInMealPlan = "Meal Exchange",
                Location = "Campus View Café - University Hall, 51 Goodman Avenue - Medical Campus",
                NameQueryParameter = "CampusViewCafé"
            },
            new DiningHall
            {
                Id = 6,
                Name = "On the Green",
                Category = "Resident Dining",
                Description = "On the Green is an all-you-care-to-eat dining facility that boasts 8 dining stations, dishing up comfort food classics, made-to-order stir-fry and pasta, homemade soups, fresh salads with local greens, and in-house baked desserts. On the Green also features Simple Servings, an allergen-friendly station committed to providing delicious, wholesome meals safely prepared free of 8 of the top allergens, plus gluten as well as Simple Zone a “pantry” where food items needed by customers with celiac disease or food allergies can be housed with precautions against cross-contact can be found.",
                IncludedInMealPlan = "Dine In",
                Location = "On The Green - Marian Spencer Hall, 2911 Scioto Lane",
                NameQueryParameter = "OTG"
            },
            new DiningHall
            {
                Id = 7,
                Name = "MarketPointe",
                Category = "Resident Dining",
                Description = "MarketPointe is a 37,000 foot state-of-the-art dining facility that boasts 8 dining stations that put you at the center of a culinary food hall experience. From delicious, plant-forward dishes and nourishing made-to-order sandwiches to authentic global bowls and craveable Latin-infused flavors, MarketPointe has something for everyone. MarketPointe also features Simple Servings, an allergen-friendly station committed to providing delicious, wholesome meals safely prepared free of 8 of the top allergens, plus gluten. Cap your dining experience with a fresh-roasted cup of local Rooted Grounds coffee and something sweet.",
                IncludedInMealPlan = "Dine In",
                Location = "MarketPointe - Siddal Hall, 2580 Corbett Drive",
                NameQueryParameter = "MarketPointe"
            },
            new DiningHall
            {
                Id = 8,
                Name = "Halal Shack",
                Category = "Retail Dining",
                Description = "At The Halal Shack, our food is Made with Love. Our culture is rooted in Middle Eastern & Mediterranean heritage which embodies bonds that are created through sharing food Made With Love. Find us at Tangeman University Center.",
                IncludedInMealPlan = "Meal Exchange after 2 P.M.",
                Location = "The Halal Shack - Tangeman University Center, 2701 Bearcat Way",
                NameQueryParameter = "HalalShack"

            },
            new DiningHall
            {
                Id = 9,
                Name = "Pei Wei",
                Category = "Retail Dining",
                Description = "Pei Wei at Tangeman University Center offers authentic, Asian-inspired cuisine without compromising on quality or convenience.",
                IncludedInMealPlan = "No",
                Location = "Pei Wei - Tangeman University Center, 2701 Bearcat Way",
                NameQueryParameter = "PeiWei"
            },
            new DiningHall
            {
                Id = 10,
                Name = "Market on Main",
                Category = "CStore",
                Description = "Market on Main is your mini-grocery store in the heart of campus! Water by the case, dairy, snacks, grab-and-go, heat-and-eat meals, beverages and more are available for all of your convenience needs.",
                IncludedInMealPlan = "No",
                Location = "Market on Main, 2820 Bearcat Way",
                NameQueryParameter = "MarketOnMain"
            },
            new DiningHall
            {
                Id = 11,
                Name = "Center Court",
                Category = "Resident Dining",
                Description = "Center Court is an expansive all-you-care-to-eat facility that boasts over a dozen unique dining destinations to feed hungry Bearcats. Enjoy favorites like pizza, handhelds, Indian cuisine from Choolaah, and made-to-order handcrafted sandwiches to an expansive salad bar, homemade soups and indulgent desserts. Center Court also features Simple Servings, an allergen-friendly station committed to providing delicious, wholesome meals safely prepared free of 8 of the top allergens, plus gluten.",
                IncludedInMealPlan = "Dine In",
                Location = "Center Court - Campus Recreation Center, 2810 Woodside Drive",
                NameQueryParameter = "CenterCourt"
            },
            new DiningHall
            {
                Id = 12,
                Name = "DAAP Café",
                Category = "Café",
                Description = "DAAP Café serves your favorite breakfast, lunch, and dinner options. The Café also serves Simply to Go sandwiches, salads, & snacks for students who are hungry and on the go. If you need a pick-me-up, we also serve iced bubble tea and Rooted Grounds coffee.",
                IncludedInMealPlan = "Meal Exchange",
                Location = "DAAP Café @ Aronoff Center, 2624 Clifton Avenue",
                NameQueryParameter = "DaapCafé"
            },
            new DiningHall
            {
                Id = 13,
                Name = "The 86 Coffee Bar",
                Category = "Café",
                Description = "Partnering with the local Pneuma Coffee Roasters, renowned for their commitment to quality, The 86 Coffee Bar offers an array of meticulously crafted brews, from rich espressos to velvety lattes. Moreover, the menu extends beyond traditional offerings, with specialty drinks inspired by the creativity of CCM's community.",
                IncludedInMealPlan = "No",
                Location = "College-Conservatory of Music, 2604 Backstage Drive",
                NameQueryParameter = "86Coffee"
            },
            new DiningHall
            {
                Id = 14,
                Name = "Mainstreet Express Mart",
                Category = "CStore",
                Description = "Salty and sweet snacks, grab-and-go salads, sandwiches, fruit cups, heat-and-eat meals, beverages and more are available at the Mainstreet Express Mart.",
                IncludedInMealPlan = "No",
                Location = "Tangeman University Center, 2701 Bearcat Way",
                NameQueryParameter = "Mainstreet"
            },
            new DiningHall
            {
                Id = 15,
                Name = "Starbucks - Linder",
                Category = "Café",
                Description = "Starbucks roasts high-quality whole bean coffees. Other premium beverage options include rich espressos, lattes, and Tazo Teas. Starbucks also serves a variety of pastries and confections.",
                IncludedInMealPlan = "No",
                Location = "Starbucks @ Lindner Hall, 2906 Woodside Drive",
                NameQueryParameter = "Starbucks_Linder"
            },
            new DiningHall
            {
                Id = 16,
                Name = "Starbucks - Langsam",
                Category = "Café",
                Description = "Starbucks roasts high-quality whole bean coffees. Other premium beverage options include rich espressos, lattes, and Tazo Teas. Starbucks also serves a variety of pastries and confections.",
                IncludedInMealPlan = "No",
                Location = "Starbucks @ Langsam Library, 2911 Woodside Drive",
                NameQueryParameter = "Starbucks_Langsam"
            },
            new DiningHall
            {
                Id = 17,
                Name = "Stadium View Café",
                Category = "Resident Dining",
                Description = "Stadium View Café features Sicilian pizza and a build-your-own rice bowl station. \nThe Café also serves an exclusive game day menu during football season.",
                IncludedInMealPlan = "Dine In and Carryout",
                Location = "Bearcats Café - Tangeman University Center, 2701 Bearcat Way",
                NameQueryParameter = "StadiumView"
            },
            new DiningHall
            {
                Id = 18,
                Name = "Starbucks - Medical Campus",
                Category = "Café",
                Description = "Starbucks roasts high-quality whole bean coffees. Other premium beverage options include rich espressos, lattes, and Tazo Teas. Starbucks also serves a variety of pastries and confections.",
                IncludedInMealPlan = "No",
                Location = "Starbucks @ Medical Science Building, 234 Goodman Drive",
                NameQueryParameter = "Starbucks_Medical"
            }
        );

        base.OnModelCreating(builder);
    }
}