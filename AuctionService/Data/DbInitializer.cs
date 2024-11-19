using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{
    
    public static void InitializeDatabase(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        SeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();
        if (context.Auctions.Any())
        {
            Console.WriteLine("Already had auctions data. No need to Seed Data.");
            return;
        }
        var auctions = new List<Auction>
            {
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 100,
                    Seller = "Alice Brown",
                    Winner = null,
                    SoldAmount = null,
                    CurrentHighBid = null,
                    AuctionEnd = DateTime.UtcNow.AddDays(7),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "SoundMaster",
                        ProductionYear = 2020,
                        Name = "1000MX4 Headphones",
                        ImageUrl = "https://imgcdn.dev/i/1000mx4-headphones.gjA38",
                        Description = "High-fidelity over-ear headphones with noise cancellation and deep bass.",
                        Category = "Audio",
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 49,
                    Seller = "Bob Dillaine",
                    AuctionEnd = DateTime.UtcNow.AddDays(11),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "AromaLux",
                        ProductionYear = 2022,
                        Name = "Aromatherapy Sleek Diffusor",
                        ImageUrl = "https://imgcdn.dev/i/aromatherapy-sleek-diffusor.gj27y",
                        Description = "A modern aromatherapy diffusor designed for optimal fragrance distribution.",
                        Category = "Home & Living",
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 60,
                    Seller = "Charlie McDonald",
                    AuctionEnd = DateTime.UtcNow.AddDays(27),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "AromaLux",
                        ProductionYear = 2023,
                        Name = "Aromatherapy Sleek Diffusor Blue",
                        Description = "A blue variant of the sleek diffusor with adjustable mist settings.",
                        ImageUrl = "https://imgcdn.dev/i/aromatherapy-sleek-diffusor-blue.gjZw2",
                        Category = "Home & Living",
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 70,
                    Seller = "Diana Daniel",
                    AuctionEnd = DateTime.UtcNow.AddDays(7),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "AromaLux",
                        ProductionYear = 2023,
                        Name = "Aromatherapy Sleek Diffusor Pink",
                        ImageUrl = "https://imgcdn.dev/i/aromatherapy-sleek-diffusor-pink.gj9Ui",
                        Description = "A stylish pink aromatherapy diffusor that enhances your decor.",
                        Category = "Home & Living",
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 199,
                    Seller = "Eva Miller",
                    AuctionEnd = DateTime.UtcNow.AddDays(7),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Artistry Home",
                        ProductionYear = 2023,
                        Name = "Art Demo Vanity Mirror Installation",
                        ImageUrl = "https://imgcdn.dev/i/art-demo-vanity-mirror-installation.gjRRH",
                        Description = "An elegant vanity mirror with integrated LED lighting for perfect reflections.",
                        Category = "Home Decor",
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 39,
                    Seller = "Frank Purry",
                    AuctionEnd = DateTime.UtcNow.AddDays(12),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "EcoCut",
                        ProductionYear = 2023,
                        Name = "Bamboo Cutting Board",
                        Description = "Eco-friendly bamboo cutting board, perfect for all your kitchen needs.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/bamboo-cutting-board.gjVoS"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 25,
                    Seller = "Gina Bricerough",
                    AuctionEnd = DateTime.UtcNow.AddDays(15),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "AudioTech",
                        ProductionYear = 2023,
                        Name = "Blue Headset",
                        Description = "Comfortable blue headset with high-quality sound and a built-in microphone.",
                        Category = "Audio",
                        ImageUrl = "https://imgcdn.dev/i/blue-headset.gjtsC"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 120,
                    Seller = "Hannah",
                    AuctionEnd = DateTime.UtcNow.AddDays(30),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Vintage Lighting",
                        ProductionYear = 2023,
                        Name = "Brass Antique Lamp",
                        Description = "A classic brass lamp that adds a touch of elegance to any room.",
                        Category = "Lighting",
                        ImageUrl = "https://imgcdn.dev/i/brass-antique-lamp.gjWxe"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 499,
                    Seller = "Ian Davis",
                    AuctionEnd = DateTime.UtcNow.AddDays(9),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Zen Decor",
                        ProductionYear = 2003,
                        Name = "Buddha Statue",
                        Description = "A serene and calming Buddha statue, perfect for meditation spaces.",
                        Category = "Home Decor",
                        ImageUrl = "https://imgcdn.dev/i/buddha-statue.gjdH0"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 19,
                    Seller = "Jack Morgan",
                    AuctionEnd = DateTime.UtcNow.AddDays(5),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "HomeScents",
                        ProductionYear = 2023,
                        Name = "Candle in Glass Jar",
                        Description = "A beautifully scented candle in a decorative glass jar, ideal for relaxation.",
                        Category = "Home Decor",
                        ImageUrl = "https://imgcdn.dev/i/candle-in-glass-jar.gjLIM"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 19,
                    Seller = "Jack Morgan",
                    AuctionEnd = DateTime.UtcNow.AddDays(8),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "HomeScents",
                        ProductionYear = 2023,
                        Name = "Candle in Glass Jar Chill",
                        Description = "A calming chill-scented candle in a chic glass jar.",
                        Category = "Home Decor",
                        ImageUrl = "https://imgcdn.dev/i/candle-in-glass-jar-chill.gjb7d"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 19,
                    Seller = "Jack Morgan",
                    AuctionEnd = DateTime.UtcNow.AddDays(14),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "HomeScents",
                        ProductionYear = 2024,
                        Name = "Candle in Glass Jar Lime",
                        Description = "A refreshing lime-scented candle in a stylish glass jar.",
                        Category = "Home Decor",
                        ImageUrl = "https://imgcdn.dev/i/candle-in-glass-jar-lime.gjeLl"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 30,
                    Seller = "Nina Simmons",
                    AuctionEnd = DateTime.UtcNow.AddDays(4),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "HomeScents",
                        ProductionYear = 2023,
                        Name = "Candle in Glass Jar Strawberry",
                        Description = "A sweet strawberry-scented candle in a beautiful glass jar.",
                        Category = "Home Fragrance",
                        ImageUrl = "https://imgcdn.dev/i/candle-in-glass-jar-strawberry.gjq6h"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 159,
                    Seller = "Oliver Smeltering",
                    AuctionEnd = DateTime.UtcNow.AddDays(2),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Fashion Luxe",
                        ProductionYear = 2020,
                        Name = "Cashmere Scarf",
                        Description = "A luxurious cashmere scarf, perfect for chilly weather.",
                        Category = "Fashion",
                        ImageUrl = "https://imgcdn.dev/i/cashmere-scarf.gjFUV"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 134,
                    Seller = "Pamela",
                    AuctionEnd = DateTime.UtcNow.AddDays(15),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Tableware Co",
                        ProductionYear = 2023,
                        Name = "Ceramic Dinnerware",
                        Description = "Beautiful ceramic dinnerware set, perfect for family gatherings.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/ceramic-dinnerware.gjHVK"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 23,
                    Seller = "Quinn Lessiter",
                    AuctionEnd = DateTime.UtcNow.AddDays(17),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "ChocoDelights",
                        ProductionYear = 2023,
                        Name = "Gourmet Chocolates",
                        Description = "Assorted gourmet chocolates for the true connoisseur.",
                        Category = "Food",
                        ImageUrl = "https://imgcdn.dev/i/gourmet-chocolates.gjXoo"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 1299,
                    Seller = "Ray Summers",
                    AuctionEnd = DateTime.UtcNow.AddDays(32),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Watches Inc",
                        ProductionYear = 2023,
                        Name = "High-End Sportswatch",
                        Description = "A luxury sportswatch with advanced features and sleek design.",
                        Category = "Fashion",
                        ImageUrl = "https://imgcdn.dev/i/high-end-sportswatch.gjEsO"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 200,
                    Seller = "Sophia Leguine",
                    AuctionEnd = DateTime.UtcNow.AddDays(16),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Culinary Magic",
                        ProductionYear = 2023,
                        Name = "InstaPot Kulinar Bro",
                        Description = "Versatile kitchen gadget that cooks, steams, and more with ease.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/instapot-kulinar-bro.gj82n"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 1299,
                    Seller = "Tony Robbinson",
                    AuctionEnd = DateTime.UtcNow.AddDays(19),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Apple",
                        ProductionYear = 2023,
                        Name = "iPhone 13 Pro",
                        Description = "The latest iPhone with advanced features and stunning design.",
                        Category = "Electronics",
                        ImageUrl = "https://imgcdn.dev/i/iphone-13-pro.gjJHg"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 129,
                    Seller = "Uma Turmallini",
                    AuctionEnd = DateTime.UtcNow.AddDays(10),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "HomeStyle",
                        ProductionYear = 2023,
                        Name = "Italian Marble Coasters",
                        Description = "Elegant coasters made from genuine Italian marble.",
                        Category = "Home & Living",
                        ImageUrl = "https://imgcdn.dev/i/italian-marble-coasters.gjpIv"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 649,
                    Seller = "Vic Marlenborough",
                    AuctionEnd = DateTime.UtcNow.AddDays(22),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Tea Masters",
                        ProductionYear = 2023,
                        Name = "Japanese Cast Iron Teapot",
                        Description = "A beautifully crafted teapot made from cast iron, perfect for tea lovers.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/japanese-cast-iron-teapot.gwDBN"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 219,
                    Seller = "Wendy Brandisson",
                    AuctionEnd = DateTime.UtcNow.AddDays(13),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Book Haven",
                        ProductionYear = 2023,
                        Name = "Leather Covered Lit Bookshelves",
                        Description = "Elegant leather-covered bookshelves for a touch of sophistication.",
                        Category = "Furniture",
                        ImageUrl = "https://imgcdn.dev/i/leather-covered-lit-bookshelfs.gwYLq"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 2499,
                    Seller = "Xander Martin",
                    AuctionEnd = DateTime.UtcNow.AddDays(4),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Aquarium Essentials",
                        ProductionYear = 2023,
                        Name = "Lumi Aquarium 200",
                        Description = "A beautifully designed aquarium with LED lighting.",
                        Category = "Aquariums",
                        ImageUrl = "https://imgcdn.dev/i/lumi-aquarium-200.gwj6B"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 399,
                    Seller = "Yara Peters",
                    AuctionEnd = DateTime.UtcNow.AddDays(7),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Bags & More",
                        ProductionYear = 2023,
                        Name = "Mahogany Messenger Bag",
                        Description = "Stylish messenger bag made from premium mahogany leather.",
                        Category = "Fashion",
                        ImageUrl = "https://imgcdn.dev/i/mahogany-messenger-bag.gwwlu"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 129,
                    Seller = "Zara Wilson",
                    AuctionEnd = DateTime.UtcNow.AddDays(12),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Coffee Pro",
                        ProductionYear = 2023,
                        Name = "Mini Barista Espresso Maker",
                        Description = "Compact espresso maker for coffee lovers.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/mini-barista-espreso-maker.gw6VL"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 999,
                    Seller = "Alex Campton",
                    AuctionEnd = DateTime.UtcNow.AddDays(3),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Rug Collection",
                        ProductionYear = 2023,
                        Name = "Moroccan Rug",
                        Description = "Handcrafted Moroccan rug that adds warmth and style to any space.",
                        Category = "Home Decor",
                        ImageUrl = "https://imgcdn.dev/i/moroccan-rug.gwMpa"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 75,
                    Seller = "Kim",
                    AuctionEnd = DateTime.UtcNow.AddDays(12),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Home Tech",
                        ProductionYear = 2023,
                        Name = "Oilorizer 3000 Z",
                        Description = "Innovative oil sprayer for easy and healthy cooking.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/oilorizer-3000-z.gwuyw"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 80,
                    Seller = "Leo Van Deere",
                    AuctionEnd = DateTime.UtcNow.AddDays(5),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Home Tech",
                        ProductionYear = 2023,
                        Name = "Oilorizer 3000 Z Purple",
                        Description = "Stylish purple oil sprayer for a modern kitchen.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/oilorizer-3000-z-purple.gw42t"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 85,
                    Seller = "Mia Lucos",
                    AuctionEnd = DateTime.UtcNow.AddDays(30),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Home Tech",
                        ProductionYear = 2023,
                        Name = "Oilorizer 3000 Z Skyblue",
                        Description = "Chic skyblue oil sprayer for your culinary needs.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/oilorizer-3000-z-skyblue.gwCXT"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 99,
                    Seller = "Owen Trenton",
                    AuctionEnd = DateTime.UtcNow.AddDays(19),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "EcoLiving",
                        ProductionYear = 2023,
                        Name = "Organic Bamboo Sheets",
                        Description = "Soft and eco-friendly bamboo sheets for a luxurious sleep.",
                        Category = "Bedding",
                        ImageUrl = "https://imgcdn.dev/i/organic-bamboo-sheets.gwNND"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 69,
                    Seller = "Paula Silverston",
                    AuctionEnd = DateTime.UtcNow.AddDays(5),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Garden Pros",
                        ProductionYear = 2023,
                        Name = "Plant Stand Black Minimalistic",
                        Description = "Sleek black plant stand, perfect for displaying your favorite plants.",
                        Category = "Home Decor",
                        ImageUrl = "https://imgcdn.dev/i/plant-stand-black-minimalistic.gwQB9"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 199,
                    Seller = "Roger Pernose",
                    AuctionEnd = DateTime.UtcNow.AddDays(97),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Tea Masters",
                        ProductionYear = 2023,
                        Name = "Porcelain Tea Set",
                        Description = "Elegant porcelain tea set for the perfect afternoon tea experience.",
                        Category = "Kitchen",
                        ImageUrl = "https://imgcdn.dev/i/porcelain-tea-set.gwiby"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 149,
                    Seller = "Sally Winslow",
                    AuctionEnd = DateTime.UtcNow.AddDays(22),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Wine Connoisseurs",
                        ProductionYear = 2023,
                        Name = "Rustic Wine Rack Criss Cross",
                        Description = "Stylish rustic wine rack, perfect for displaying your wine collection.",
                        Category = "Furniture",
                        ImageUrl = "https://imgcdn.dev/i/rustic-wine-rack-criss-cross.gwn68"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 29,
                    Seller = "Tracy Chickenz",
                    AuctionEnd = DateTime.UtcNow.AddDays(11),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Cozy Home",
                        ProductionYear = 2023,
                        Name = "Vibrant Pillow Cover",
                        Description = "Bright and vibrant pillow cover to liven up your living space.",
                        Category = "Home Decor",
                        ImageUrl = "https://imgcdn.dev/i/vibrant-pillow-cover.gwsl2"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 299,
                    Seller = "Vincent Roberts",
                    AuctionEnd = DateTime.UtcNow.AddDays(7),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Vintage Bags",
                        ProductionYear = 2023,
                        Name = "Vintage Backpack Leather",
                        Description = "Classic leather backpack with vintage design, perfect for everyday use.",
                        Category = "Fashion",
                        ImageUrl = "https://imgcdn.dev/i/vintage-backpack-leather.gwyfi"
                    }
                },
                new Auction
                {
                    Id = Guid.NewGuid(),
                    ReservedPrice = 14999,
                    Seller = "Walt Spencer",
                    AuctionEnd = DateTime.UtcNow.AddDays(79),
                    Status = Status.Live,
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Manufacturer = "Auto Gear",
                        ProductionYear = 2023,
                        Name = "VW Polo Sport",
                        Description = "Stylish and sporty VW Polo, perfect for city driving.",
                        Category = "Automobiles",
                        ImageUrl = "https://imgcdn.dev/i/vw-polo-sport.gw5pH"
                    }
                }
            };

        
        context.AddRange(auctions);
        context.SaveChanges();
    }
}