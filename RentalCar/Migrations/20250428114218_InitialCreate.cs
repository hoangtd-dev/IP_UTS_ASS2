using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalCar.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    YearOfManufacture = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Mileage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false),
                    CarTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Cars_CarBrands_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarTypes_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "CarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<string>(type: "nvarchar(17)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverLicense = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalPeriod = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarReservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Honda" },
                    { 3, "Ford" },
                    { 4, "Chevrolet" }
                });

            migrationBuilder.InsertData(
                table: "CarTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SUV" },
                    { 2, "Sedan" },
                    { 3, "Hatchback" },
                    { 4, "Convertible" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "VIN", "CarBrandId", "CarModel", "CarTypeId", "Description", "FuelType", "ImageUrl", "IsAvailable", "Mileage", "Name", "PricePerDay", "YearOfManufacture" },
                values: new object[,]
                {
                    { "00AC159762974A10B", 2, "Beat", 4, "Kei-car roadster.", "Gasoline", "https://carsales.pxcrush.net/carsales/car/dealer/f08bafd961687e9e1ea8d73e3d1325e6.jpg?pxc_method=fitfill&pxc_bgtype=self&pxc_size=720,480", false, 50000m, "Honda Beat", 50.00m, 1995 },
                    { "183ED369F7914A949", 3, "Fiesta ST", 3, "Small but sporty hatchback.", "Gasoline", "https://images.carexpert.com.au/resize/3000/-/app/uploads/2022/09/ford-fiesta-st-58.jpg", true, 25000m, "Ford Fiesta ST", 50.00m, 2019 },
                    { "1ACCC27361EC4BE89", 2, "Pilot", 1, "Family-friendly 8-seater.", "Gasoline", "https://www.usnews.com/object/image/0000018c-457f-dc8f-addc-ef7fda470001/24-honda-pilot-ext1.jpg?update-time=1701973208102&size=responsiveGallery", true, 20000m, "Honda Pilot", 60.00m, 2020 },
                    { "29C842DF4DC54700A", 2, "S2000", 4, "Legendary high-revving roadster.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/d/dc/HondaS2000-004.jpg", true, 30000m, "Honda S2000", 100.00m, 2009 },
                    { "2B0DB732485F4929A", 1, "Mirai", 2, "Hydrogen fuel cell vehicle.", "Hydrogen", "https://images.autodaily.com.au/2021/05/Toyota-Mirai-2021-UK-11.jpg", true, 2000m, "Toyota Mirai", 75.00m, 2023 },
                    { "2DC9BB393BB34B8FA", 1, "4Runner", 1, "Off-road capable SUV.", "Gasoline", "https://media.ed.edmunds-media.com/toyota/4runner/2025/oem/2025_toyota_4runner_4dr-suv_limited_fq_oem_1_1280.jpg", true, 25000m, "Toyota 4Runner", 70.00m, 2019 },
                    { "4466B4FA6C834F998", 1, "bZ4X", 1, "Toyota's electric SUV.", "Electric", "https://nextgen-images.cdn.dealersolutions.com.au/modular.multisite.dealer.solutions/wp-content/uploads/sites/1674/2024/02/28151424/Toyota-Pressroom-650c4be0-c60a-4a67-9771-79ca946cdb88-1200x675.jpeg?format=webp&width=1200", true, 3000m, "Toyota bZ4X", 60.00m, 2023 },
                    { "4B37AFA83FC64F068", 1, "Celica", 4, "Classic 90s convertible.", "Gasoline", "https://media.carsandbids.com/cdn-cgi/image/width=2080,quality=70/30eaf80ceaa3b7a461a21047b172db29a6c3daa6/photos/Kdx27R15-D57YR1EU0r-(edit).jpg?t=171419188311", true, 60000m, "Toyota Celica Convertible", 45.00m, 2000 },
                    { "4FD4B23DD7924FCAA", 1, "Corolla Hatchback", 3, "Sporty and practical.", "Gasoline", "https://www.motortrend.com/uploads/sites/5/2018/04/2019-Toyota-Corolla-Hatchback-XSE-front-three-quarter-02.jpg?w=768&width=768&q=75&format=webp", true, 5000m, "Toyota Corolla Hatchback", 40.00m, 2023 },
                    { "53AFC8435F7B4F73A", 1, "Highlander", 1, "Spacious 7-seater SUV.", "Hybrid", "https://media.whichcar.com.au/uploads/2023/02/5884556b-2024_Toyota_Grand_Highlander_Kluger_01.jpg", true, 10000m, "Toyota Highlander", 65.00m, 2021 },
                    { "58605AF376FF4D868", 3, "Focus CC", 4, "Retractable hardtop convertible.", "Gasoline", "https://media.autoexpress.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1562250430/autoexpress/images/car_photo_216766.jpg", true, 40000m, "Ford Focus CC", 45.00m, 2010 },
                    { "5BA1058C793341A7A", 3, "Thunderbird", 4, "Classic luxury convertible.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/5/5b/1957_Ford_Thunderbird_%2828911503716%29_%28cropped%29.jpg", true, 35000m, "Ford Thunderbird", 60.00m, 2005 },
                    { "5E63BAF3DEBE495C8", 4, "Tahoe", 1, "Full-size family SUV.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/2/22/2022_Chevrolet_Tahoe_RST%2C_front_3.7.22.jpg", true, 9000m, "Chevrolet Tahoe", 70.00m, 2022 },
                    { "69DB84D2876B4E409", 2, "Insight", 2, "Fuel-efficient hybrid sedan.", "Hybrid", "https://www.driva.com.au/static/971605b37cc6166334ea45d03e5963d9/6b6b2/6073b3bb-9dc9-4277-a094-3f78d58d2a55_image5.jpg", true, 12000m, "Honda Insight", 50.00m, 2021 },
                    { "6A35CB6C8B5C46CFA", 3, "Escape", 1, "Compact crossover SUV.", "Hybrid", "https://images.carexpert.com.au/resize/3000/-/app/uploads/2023/04/2023-Ford-Escape-ST-Line-FWD_230414_Ford-Escape-ST-Line-FWD_Still-4.jpg", true, 10000m, "Ford Escape", 48.00m, 2022 },
                    { "6D3A7C141ADA48FEA", 2, "CR-V", 1, "Best-selling compact SUV.", "Hybrid", "https://i0.wp.com/practicalmotoring.com.au/wp-content/uploads/2017/07/Honda-CR-V-VTi-LX-16.jpg?fit=768%2C526&ssl=1", false, 18000m, "Honda CR-V", 52.00m, 2021 },
                    { "6DDBE327344D4D7B8", 2, "Accord", 2, "Sleek midsize sedan.", "Hybrid", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/26/2023_Honda_Accord_LX%2C_front_left%2C_07-13-2023.jpg/960px-2023_Honda_Accord_LX%2C_front_left%2C_07-13-2023.jpg", true, 6000m, "Honda Accord", 48.00m, 2023 },
                    { "70652F8FDF784595A", 2, "Del Sol", 4, "90s targa-top convertible.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b3/1994_Honda_Civic_del_Sol_Si.jpg/1200px-1994_Honda_Civic_del_Sol_Si.jpg", true, 60000m, "Honda Del Sol", 45.00m, 1997 },
                    { "7364F8738833413D8", 3, "Taurus", 2, "Full-size sedan with space.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bb/05-07_Ford_Taurus_SE_sedan.jpg/1200px-05-07_Ford_Taurus_SE_sedan.jpg", true, 25000m, "Ford Taurus", 50.00m, 2019 },
                    { "7EDCEA7DD61C4183A", 1, "Crown", 2, "Luxury sedan with elevated design.", "Hybrid", "https://cdn.motor1.com/images/mgl/JvQ8Q/s1/2021-toyota-crown-update.webp", true, 4000m, "Toyota Crown", 65.00m, 2023 },
                    { "7FE0CB5CA06B4046A", 4, "Bolt EV", 3, "Affordable electric hatchback.", "Electric", "https://bucket.dealervenom.com/2023/10/design22CHBO35004_960x500.jpg?auto=compress%2Cformat&ixlib=php-3.3.1", true, 5000m, "Chevrolet Bolt EV", 45.00m, 2023 },
                    { "8090E20E3A8A41BD8", 4, "Suburban", 1, "Massive 9-seater SUV.", "Gasoline", "https://images.carexpert.com.au/resize/3000/-/app/uploads/2023/12/chevrolet-suburban-1.jpg", true, 12000m, "Chevrolet Suburban", 80.00m, 2021 },
                    { "8E5EB01632F94470B", 1, "Avalon", 2, "Premium full-size sedan.", "Hybrid", "https://bucket.dealervenom.com/robinson-toyota/uploads/2017/08/30205601/272617-min.jpg?fm=pjpg&ixlib=php-3.3.1", true, 12000m, "Toyota Avalon", 55.00m, 2021 },
                    { "9F58DC1FE2874E789", 1, "Land Cruiser", 1, "Luxury off-road vehicle.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/2021_Toyota_Land_Cruiser_300_3.4_ZX_%28Colombia%29_front_view_04.png/960px-2021_Toyota_Land_Cruiser_300_3.4_ZX_%28Colombia%29_front_view_04.png", true, 5000m, "Toyota Land Cruiser", 120.00m, 2022 },
                    { "AAA4B1228BB444FC8", 1, "MR2 Spyder", 4, "Mid-engine roadster.", "Gasoline", "https://hips.hearstapps.com/hmg-prod/images/2003-mr2-spyder-2-1599224809.jpg", true, 45000m, "Toyota MR2 Spyder", 60.00m, 2005 },
                    { "AAC00E53569D437CB", 2, "Civic", 2, "Popular compact sedan.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Honda_Civic_e-HEV_Sport_%28XI%29_%E2%80%93_f_30062024.jpg/960px-Honda_Civic_e-HEV_Sport_%28XI%29_%E2%80%93_f_30062024.jpg", true, 10000m, "Honda Civic", 42.00m, 2022 },
                    { "AB6D22AC047843248", 1, "Camry", 2, "Reliable midsize sedan.", "Gasoline", "https://redriven.com/wp-content/uploads/2024/07/Toyota-Camry-XV70-15-1024x683.jpg", true, 8000m, "Toyota Camry", 45.00m, 2022 },
                    { "AB88EF88C7E64D9F9", 2, "e:NS1", 1, "Honda's electric SUV.", "Electric", "https://marketplace.china-crunch.com/cdn/shop/files/honda_e_ns1_evmarketplace_chinacrunch_02.png?v=1689441717", true, 2000m, "Honda e:NS1", 55.00m, 2023 },
                    { "AFD57038FF444C22B", 1, "Prius", 2, "Iconic hybrid sedan.", "Hybrid", "https://upload.wikimedia.org/wikipedia/commons/f/fa/2016_Toyota_Prius_%28ZVW50L%29_Hybrid_liftback_%282016-04-02%29_01.jpg", false, 10000m, "Toyota Prius", 40.00m, 2022 },
                    { "B13FD9E98BA449219", 1, "Venza", 1, "Stylish crossover SUV.", "Hybrid", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdoSLEPuOLBPAyKuDSt2znlsj2i0zg3Zj5uA&s", true, 12000m, "Toyota Venza", 55.00m, 2021 },
                    { "B2F820FBD20F4C788", 3, "Puma", 3, "Stylish subcompact crossover.", "Hybrid", "https://www.topgear.com/sites/default/files/2024/09/Puma_IMHEV_ST_LINE_018.jpg", true, 10000m, "Ford Puma", 48.00m, 2022 },
                    { "B4F86B7EDF5D45BCA", 1, "RAV4", 1, "Compact SUV with great fuel efficiency.", "Gasoline", "https://www.topgear.com/sites/default/files/2024/09/Toyota-RAV4-Hybrid-036.jpg", true, 15000m, "Toyota RAV4", 50.00m, 2020 },
                    { "BD1EBAD76EEC421DA", 3, "Bronco", 1, "Iconic off-road SUV.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Ford_Bronco_%286th_generation%29_Outer_Banks_1X7A0384.jpg/1200px-Ford_Bronco_%286th_generation%29_Outer_Banks_1X7A0384.jpg", true, 5000m, "Ford Bronco", 70.00m, 2023 },
                    { "CF83662C0C3C4EDDB", 1, "Supra", 4, "Sporty convertible with BMW roots.", "Gasoline", "https://nextgen-images.cdn.dealersolutions.com.au/modular.multisite.dealer.solutions/wp-content/uploads/sites/1674/2022/09/12104523/64112_800.jpg?format=webp&width=800", true, 7000m, "Toyota Supra", 90.00m, 2022 },
                    { "D32D080C17A64C69A", 2, "Civic Hatchback", 3, "Sporty and practical hatch.", "Gasoline", "https://carsguide-res.cloudinary.com/image/upload/c_fit,h_841,w_1490,f_auto,t_cg_base/v1/editorial/2017-civic-hatch-(3).jpg", true, 5000m, "Honda Civic Hatchback", 45.00m, 2023 },
                    { "D7FB570286F143D98", 3, "Focus", 2, "Compact and efficient.", "Gasoline", "https://redriven.com/wp-content/uploads/2024/11/Ford-Focus-ST-1-scaled.jpg", true, 30000m, "Ford Focus", 40.00m, 2018 },
                    { "D933DBA41C4D4931A", 3, "Fusion", 2, "Comfortable midsize sedan.", "Hybrid", "https://www.vdm.ford.com/content/dam/brand_ford/en_us/brand/cars/fusion/sunset/FL10383620_FUSI_Hyb_SE_34FrntPassStcVlctyBlueNight_mj_16x9.jpg/jcr:content/renditions/cq5dam.web.768.768.jpeg", true, 22000m, "Ford Fusion", 46.00m, 2020 },
                    { "D93F663BFBE7452EB", 2, "Jazz", 3, "Global name for the Honda Fit.", "Hybrid", "https://i.ytimg.com/vi/yGRqTkx7vzk/hqdefault.jpg", true, 10000m, "Honda Jazz", 36.00m, 2022 },
                    { "DE83CD5AEA534DB19", 1, "GR Corolla", 3, "High-performance hot hatch.", "Gasoline", "https://nextgen-images.cdn.dealersolutions.com.au/modular.multisite.dealer.solutions/wp-content/uploads/sites/1576/2022/04/05064930/63814_hr-scaled.jpg?format=webp&width=2560", true, 3000m, "Toyota GR Corolla", 80.00m, 2023 },
                    { "E1B986AF5BC84EDA9", 1, "Corolla", 2, "Compact and fuel-efficient.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/f/fe/Toyota_Corolla_Hybrid_%28E210%29_IMG_4338.jpg", true, 5000m, "Toyota Corolla", 35.00m, 2023 },
                    { "E1C86921ACCD4522B", 4, "Impala", 2, "Classic full-size sedan.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Chevrolet_Impala_%2814373209694%29.jpg/330px-Chevrolet_Impala_%2814373209694%29.jpg", true, 18000m, "Chevrolet Impala", 52.00m, 2020 },
                    { "E6A22FEEC5A94641B", 3, "Explorer", 1, "Rugged family SUV.", "Gasoline", "https://www.carpro.com/hs-fs/hubfs/2025-Ford-Explorer-ST-hero-credit-ford.jpg?width=1020&name=2025-Ford-Explorer-ST-hero-credit-ford.jpg", true, 15000m, "Ford Explorer", 58.00m, 2021 },
                    { "E7C341890D0F40AD8", 3, "Mustang Convertible", 4, "Iconic American muscle car.", "Gasoline", "https://seven82files.s3.amazonaws.com/wp-content/uploads/2021/09/1965-Ford-Mustang-convertible-1.jpg", true, 5000m, "Ford Mustang Convertible", 75.00m, 2023 },
                    { "E8A52964EF0243FEA", 2, "Fit", 3, "Ultra-spacious subcompact.", "Gasoline", "https://www.cnet.com/a/img/resize/f970bb01b111c14e98d648df6a5e3ca17a233d3e/hub/2018/05/23/7173ead9-6e73-43e9-81b6-7e2cf165bc18/2018-honda-fit-promo.jpg?auto=webp&fit=crop&height=675&width=1200", true, 15000m, "Honda Fit", 35.00m, 2021 },
                    { "E8AF438F314F4CE38", 1, "Soarer", 4, "Vintage luxury convertible.", "Gasoline", "https://www.japancardirect.com/wp-content/uploads/2023/01/UZZ40-0009500_2_vga-640x456-1-640x420.jpg", false, 80000m, "Toyota Soarer Convertible", 55.00m, 1995 },
                    { "E9883722348B4C0FB", 4, "Malibu", 2, "Comfortable midsize sedan.", "Gasoline", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Chevrolet_Malibu_LT_%28IX%2C_Facelift%29_%E2%80%93_f_02112024.jpg/1200px-Chevrolet_Malibu_LT_%28IX%2C_Facelift%29_%E2%80%93_f_02112024.jpg", true, 12000m, "Chevrolet Malibu", 48.00m, 2022 },
                    { "EACF2621777E46258", 4, "Sonic", 2, "Compact budget sedan.", "Gasoline", "https://cdn-fastly.thetruthaboutcars.com/media/2022/07/20/9417453/review-2012-chevrolet-sonic-lt.jpg?size=720x845&nocrop=1", false, 25000m, "Chevrolet Sonic", 38.00m, 2019 },
                    { "EDBAE1B21CF140229", 1, "Prius Prime", 3, "Hybrid hatchback with EV mode.", "Plug-in Hybrid", "https://www.digitaltrends.com/wp-content/uploads/2023/07/2023-Toyota-Prius-Prime-front-three-quarter.jpeg?fit=1500%2C1000&p=1", true, 8000m, "Toyota Prius Prime", 50.00m, 2022 },
                    { "F5A54530FD294656A", 4, "Equinox", 1, "Compact crossover SUV.", "Gasoline", "https://media.ed.edmunds-media.com/chevrolet/equinox/2022/oem/2022_chevrolet_equinox_4dr-suv_rs_fq_oem_1_1600.jpg", true, 6000m, "Chevrolet Equinox", 55.00m, 2023 },
                    { "F8A6722F7EF94D21B", 3, "Focus ST", 3, "Hot hatch performance model.", "Gasoline", "https://www.topgear.com/sites/default/files/cars-car/inline-gallery/2024/10/1-Ford-Focus-ST-Edition-review-2024.jpg", false, 20000m, "Ford Focus ST", 55.00m, 2020 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_CarId",
                table: "CarReservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBrandId",
                table: "Cars",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars",
                column: "CarTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarReservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropTable(
                name: "CarTypes");
        }
    }
}
