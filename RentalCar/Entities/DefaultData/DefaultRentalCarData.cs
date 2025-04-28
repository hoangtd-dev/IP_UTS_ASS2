using Microsoft.EntityFrameworkCore;

namespace RentalCar.Entities.DefaultData
{
    public static class DefaultRentalCarData
    {
        public static void SetupDefaultData(ModelBuilder builder)
        {
            // Car Types
            var carTypes = new List<CarType>
            {
                new CarType { Id = 1, Name = "SUV" },
                new CarType { Id = 2, Name = "Sedan" },
                new CarType { Id = 3, Name = "Hatchback" },
                new CarType { Id = 4, Name = "Convertible" }
            };
            builder.Entity<CarType>().HasData(carTypes);

            // Car Brands
            var carBrands = new List<CarBrand>
            {
                new CarBrand { Id = 1, Name = "Toyota" },
                new CarBrand { Id = 2, Name = "Honda" },
                new CarBrand { Id = 3, Name = "Ford" },
                new CarBrand { Id = 4, Name = "Chevrolet" }
            };

            builder.Entity<CarBrand>().HasData(carBrands);

            // Cars
            var cars = new List<Car>
            {
                new Car { Name = "Toyota RAV4", ImageUrl = "https://www.topgear.com/sites/default/files/2024/09/Toyota-RAV4-Hybrid-036.jpg", PricePerDay = 50.00m, YearOfManufacture = 2020, Mileage = 15000, FuelType = "Gasoline", Description = "Compact SUV with great fuel efficiency.", IsAvailable = true, CarModel = "RAV4", CarBrandId = 1, CarTypeId = 1 },
                new Car { Name = "Toyota Highlander", ImageUrl = "https://media.whichcar.com.au/uploads/2023/02/5884556b-2024_Toyota_Grand_Highlander_Kluger_01.jpg", PricePerDay = 65.00m, YearOfManufacture = 2021, Mileage = 10000, FuelType = "Hybrid", Description = "Spacious 7-seater SUV.", IsAvailable = true, CarModel = "Highlander", CarBrandId = 1, CarTypeId = 1 },
                new Car { Name = "Toyota 4Runner", ImageUrl = "https://media.ed.edmunds-media.com/toyota/4runner/2025/oem/2025_toyota_4runner_4dr-suv_limited_fq_oem_1_1280.jpg", PricePerDay = 70.00m, YearOfManufacture = 2019, Mileage = 25000, FuelType = "Gasoline", Description = "Off-road capable SUV.", IsAvailable = true, CarModel = "4Runner", CarBrandId = 1, CarTypeId = 1 },
                new Car { Name = "Toyota Land Cruiser", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/2021_Toyota_Land_Cruiser_300_3.4_ZX_%28Colombia%29_front_view_04.png/960px-2021_Toyota_Land_Cruiser_300_3.4_ZX_%28Colombia%29_front_view_04.png", PricePerDay = 120.00m, YearOfManufacture = 2022, Mileage = 5000, FuelType = "Gasoline", Description = "Luxury off-road vehicle.", IsAvailable = true, CarModel = "Land Cruiser", CarBrandId = 1, CarTypeId = 1 },
                new Car { Name = "Toyota Venza", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdoSLEPuOLBPAyKuDSt2znlsj2i0zg3Zj5uA&s", PricePerDay = 55.00m, YearOfManufacture = 2021, Mileage = 12000, FuelType = "Hybrid", Description = "Stylish crossover SUV.", IsAvailable = true, CarModel = "Venza", CarBrandId = 1, CarTypeId = 1 },
                new Car { Name = "Toyota bZ4X", ImageUrl = "https://nextgen-images.cdn.dealersolutions.com.au/modular.multisite.dealer.solutions/wp-content/uploads/sites/1674/2024/02/28151424/Toyota-Pressroom-650c4be0-c60a-4a67-9771-79ca946cdb88-1200x675.jpeg?format=webp&width=1200", PricePerDay = 60.00m, YearOfManufacture = 2023, Mileage = 3000, FuelType = "Electric", Description = "Toyota's electric SUV.", IsAvailable = true, CarModel = "bZ4X", CarBrandId = 1, CarTypeId = 1 },

                new Car { Name = "Toyota Camry", ImageUrl = "https://redriven.com/wp-content/uploads/2024/07/Toyota-Camry-XV70-15-1024x683.jpg", PricePerDay = 45.00m, YearOfManufacture = 2022, Mileage = 8000, FuelType = "Gasoline", Description = "Reliable midsize sedan.", IsAvailable = true, CarModel = "Camry", CarBrandId = 1, CarTypeId = 2 },
                new Car { Name = "Toyota Avalon", ImageUrl = "https://bucket.dealervenom.com/robinson-toyota/uploads/2017/08/30205601/272617-min.jpg?fm=pjpg&ixlib=php-3.3.1", PricePerDay = 55.00m, YearOfManufacture = 2021, Mileage = 12000, FuelType = "Hybrid", Description = "Premium full-size sedan.", IsAvailable = true, CarModel = "Avalon", CarBrandId = 1, CarTypeId = 2 },
                new Car { Name = "Toyota Corolla", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/fe/Toyota_Corolla_Hybrid_%28E210%29_IMG_4338.jpg", PricePerDay = 35.00m, YearOfManufacture = 2023, Mileage = 5000, FuelType = "Gasoline", Description = "Compact and fuel-efficient.", IsAvailable = true, CarModel = "Corolla", CarBrandId = 1, CarTypeId = 2 },
                new Car { Name = "Toyota Mirai", ImageUrl = "https://images.autodaily.com.au/2021/05/Toyota-Mirai-2021-UK-11.jpg", PricePerDay = 75.00m, YearOfManufacture = 2023, Mileage = 2000, FuelType = "Hydrogen", Description = "Hydrogen fuel cell vehicle.", IsAvailable = true, CarModel = "Mirai", CarBrandId = 1, CarTypeId = 2 },
                new Car { Name = "Toyota Crown", ImageUrl = "https://cdn.motor1.com/images/mgl/JvQ8Q/s1/2021-toyota-crown-update.webp", PricePerDay = 65.00m, YearOfManufacture = 2023, Mileage = 4000, FuelType = "Hybrid", Description = "Luxury sedan with elevated design.", IsAvailable = true, CarModel = "Crown", CarBrandId = 1, CarTypeId = 2 },
                new Car { Name = "Toyota Prius", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/fa/2016_Toyota_Prius_%28ZVW50L%29_Hybrid_liftback_%282016-04-02%29_01.jpg", PricePerDay = 40.00m, YearOfManufacture = 2022, Mileage = 10000, FuelType = "Hybrid", Description = "Iconic hybrid sedan.", IsAvailable = false, CarModel = "Prius", CarBrandId = 1, CarTypeId = 2 },

                new Car { Name = "Toyota Corolla Hatchback", ImageUrl = "https://www.motortrend.com/uploads/sites/5/2018/04/2019-Toyota-Corolla-Hatchback-XSE-front-three-quarter-02.jpg?w=768&width=768&q=75&format=webp", PricePerDay = 40.00m, YearOfManufacture = 2023, Mileage = 5000, FuelType = "Gasoline", Description = "Sporty and practical.", IsAvailable = true, CarModel = "Corolla Hatchback", CarBrandId = 1, CarTypeId = 3 },
                new Car { Name = "Toyota Prius Prime", ImageUrl = "https://www.digitaltrends.com/wp-content/uploads/2023/07/2023-Toyota-Prius-Prime-front-three-quarter.jpeg?fit=1500%2C1000&p=1", PricePerDay = 50.00m, YearOfManufacture = 2022, Mileage = 8000, FuelType = "Plug-in Hybrid", Description = "Hybrid hatchback with EV mode.", IsAvailable = true, CarModel = "Prius Prime", CarBrandId = 1, CarTypeId = 3 },
                new Car { Name = "Toyota GR Corolla", ImageUrl = "https://nextgen-images.cdn.dealersolutions.com.au/modular.multisite.dealer.solutions/wp-content/uploads/sites/1576/2022/04/05064930/63814_hr-scaled.jpg?format=webp&width=2560", PricePerDay = 80.00m, YearOfManufacture = 2023, Mileage = 3000, FuelType = "Gasoline", Description = "High-performance hot hatch.", IsAvailable = true, CarModel = "GR Corolla", CarBrandId = 1, CarTypeId = 3 },

                new Car { Name = "Toyota Supra", ImageUrl = "https://nextgen-images.cdn.dealersolutions.com.au/modular.multisite.dealer.solutions/wp-content/uploads/sites/1674/2022/09/12104523/64112_800.jpg?format=webp&width=800", PricePerDay = 90.00m, YearOfManufacture = 2022, Mileage = 7000, FuelType = "Gasoline", Description = "Sporty convertible with BMW roots.", IsAvailable = true, CarModel = "Supra", CarBrandId = 1, CarTypeId = 4 },
                new Car { Name = "Toyota MR2 Spyder", ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/2003-mr2-spyder-2-1599224809.jpg", PricePerDay = 60.00m, YearOfManufacture = 2005, Mileage = 45000, FuelType = "Gasoline", Description = "Mid-engine roadster.", IsAvailable = true, CarModel = "MR2 Spyder", CarBrandId = 1, CarTypeId = 4 },
                new Car { Name = "Toyota Celica Convertible", ImageUrl = "https://media.carsandbids.com/cdn-cgi/image/width=2080,quality=70/30eaf80ceaa3b7a461a21047b172db29a6c3daa6/photos/Kdx27R15-D57YR1EU0r-(edit).jpg?t=171419188311", PricePerDay = 45.00m, YearOfManufacture = 2000, Mileage = 60000, FuelType = "Gasoline", Description = "Classic 90s convertible.", IsAvailable = true, CarModel = "Celica", CarBrandId = 1, CarTypeId = 4 },
                new Car { Name = "Toyota Soarer Convertible", ImageUrl = "https://www.japancardirect.com/wp-content/uploads/2023/01/UZZ40-0009500_2_vga-640x456-1-640x420.jpg", PricePerDay = 55.00m, YearOfManufacture = 1995, Mileage = 80000, FuelType = "Gasoline", Description = "Vintage luxury convertible.", IsAvailable = false, CarModel = "Soarer", CarBrandId = 1, CarTypeId = 4 },

                new Car { Name = "Honda CR-V", ImageUrl = "https://i0.wp.com/practicalmotoring.com.au/wp-content/uploads/2017/07/Honda-CR-V-VTi-LX-16.jpg?fit=768%2C526&ssl=1", PricePerDay = 52.00m, YearOfManufacture = 2021, Mileage = 18000, FuelType = "Hybrid", Description = "Best-selling compact SUV.", IsAvailable = false, CarModel = "CR-V", CarBrandId = 2, CarTypeId = 1 },
                new Car { Name = "Honda Pilot", ImageUrl = "https://www.usnews.com/object/image/0000018c-457f-dc8f-addc-ef7fda470001/24-honda-pilot-ext1.jpg?update-time=1701973208102&size=responsiveGallery", PricePerDay = 60.00m, YearOfManufacture = 2020, Mileage = 20000, FuelType = "Gasoline", Description = "Family-friendly 8-seater.", IsAvailable = true, CarModel = "Pilot", CarBrandId = 2, CarTypeId = 1 },
                new Car { Name = "Honda e:NS1", ImageUrl = "https://marketplace.china-crunch.com/cdn/shop/files/honda_e_ns1_evmarketplace_chinacrunch_02.png?v=1689441717", PricePerDay = 55.00m, YearOfManufacture = 2023, Mileage = 2000, FuelType = "Electric", Description = "Honda's electric SUV.", IsAvailable = true, CarModel = "e:NS1", CarBrandId = 2, CarTypeId = 1 },

                new Car { Name = "Honda Accord", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/26/2023_Honda_Accord_LX%2C_front_left%2C_07-13-2023.jpg/960px-2023_Honda_Accord_LX%2C_front_left%2C_07-13-2023.jpg", PricePerDay = 48.00m, YearOfManufacture = 2023, Mileage = 6000, FuelType = "Hybrid", Description = "Sleek midsize sedan.", IsAvailable = true, CarModel = "Accord", CarBrandId = 2, CarTypeId = 2 },
                new Car { Name = "Honda Civic", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Honda_Civic_e-HEV_Sport_%28XI%29_%E2%80%93_f_30062024.jpg/960px-Honda_Civic_e-HEV_Sport_%28XI%29_%E2%80%93_f_30062024.jpg", PricePerDay = 42.00m, YearOfManufacture = 2022, Mileage = 10000, FuelType = "Gasoline", Description = "Popular compact sedan.", IsAvailable = true, CarModel = "Civic", CarBrandId = 2, CarTypeId = 2 },
                new Car { Name = "Honda Insight", ImageUrl = "https://www.driva.com.au/static/971605b37cc6166334ea45d03e5963d9/6b6b2/6073b3bb-9dc9-4277-a094-3f78d58d2a55_image5.jpg", PricePerDay = 50.00m, YearOfManufacture = 2021, Mileage = 12000, FuelType = "Hybrid", Description = "Fuel-efficient hybrid sedan.", IsAvailable = true, CarModel = "Insight", CarBrandId = 2, CarTypeId = 2 },

                new Car { Name = "Honda Civic Hatchback", ImageUrl = "https://carsguide-res.cloudinary.com/image/upload/c_fit,h_841,w_1490,f_auto,t_cg_base/v1/editorial/2017-civic-hatch-(3).jpg", PricePerDay = 45.00m, YearOfManufacture = 2023, Mileage = 5000, FuelType = "Gasoline", Description = "Sporty and practical hatch.", IsAvailable = true, CarModel = "Civic Hatchback", CarBrandId = 2, CarTypeId = 3 },
                new Car { Name = "Honda Fit", ImageUrl = "https://www.cnet.com/a/img/resize/f970bb01b111c14e98d648df6a5e3ca17a233d3e/hub/2018/05/23/7173ead9-6e73-43e9-81b6-7e2cf165bc18/2018-honda-fit-promo.jpg?auto=webp&fit=crop&height=675&width=1200", PricePerDay = 35.00m, YearOfManufacture = 2021, Mileage = 15000, FuelType = "Gasoline", Description = "Ultra-spacious subcompact.", IsAvailable = true, CarModel = "Fit", CarBrandId = 2, CarTypeId = 3 },
                new Car { Name = "Honda Jazz", ImageUrl = "https://i.ytimg.com/vi/yGRqTkx7vzk/hqdefault.jpg", PricePerDay = 36.00m, YearOfManufacture = 2022, Mileage = 10000, FuelType = "Hybrid", Description = "Global name for the Honda Fit.", IsAvailable = true, CarModel = "Jazz", CarBrandId = 2, CarTypeId = 3 },

                new Car { Name = "Honda S2000", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/dc/HondaS2000-004.jpg", PricePerDay = 100.00m, YearOfManufacture = 2009, Mileage = 30000, FuelType = "Gasoline", Description = "Legendary high-revving roadster.", IsAvailable = true, CarModel = "S2000", CarBrandId = 2, CarTypeId = 4 },
                new Car { Name = "Honda Del Sol", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b3/1994_Honda_Civic_del_Sol_Si.jpg/1200px-1994_Honda_Civic_del_Sol_Si.jpg", PricePerDay = 45.00m, YearOfManufacture = 1997, Mileage = 60000, FuelType = "Gasoline", Description = "90s targa-top convertible.", IsAvailable = true, CarModel = "Del Sol", CarBrandId = 2, CarTypeId = 4 },
                new Car { Name = "Honda Beat", ImageUrl = "https://carsales.pxcrush.net/carsales/car/dealer/f08bafd961687e9e1ea8d73e3d1325e6.jpg?pxc_method=fitfill&pxc_bgtype=self&pxc_size=720,480", PricePerDay = 50.00m, YearOfManufacture = 1995, Mileage = 50000, FuelType = "Gasoline", Description = "Kei-car roadster.", IsAvailable = false, CarModel = "Beat", CarBrandId = 2, CarTypeId = 4 },

                new Car { Name = "Ford Explorer", ImageUrl = "https://www.carpro.com/hs-fs/hubfs/2025-Ford-Explorer-ST-hero-credit-ford.jpg?width=1020&name=2025-Ford-Explorer-ST-hero-credit-ford.jpg", PricePerDay = 58.00m, YearOfManufacture = 2021, Mileage = 15000, FuelType = "Gasoline", Description = "Rugged family SUV.", IsAvailable = true, CarModel = "Explorer", CarBrandId = 3, CarTypeId = 1 },
                new Car { Name = "Ford Escape", ImageUrl = "https://images.carexpert.com.au/resize/3000/-/app/uploads/2023/04/2023-Ford-Escape-ST-Line-FWD_230414_Ford-Escape-ST-Line-FWD_Still-4.jpg", PricePerDay = 48.00m, YearOfManufacture = 2022, Mileage = 10000, FuelType = "Hybrid", Description = "Compact crossover SUV.", IsAvailable = true, CarModel = "Escape", CarBrandId = 3, CarTypeId = 1 },
                new Car { Name = "Ford Bronco", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Ford_Bronco_%286th_generation%29_Outer_Banks_1X7A0384.jpg/1200px-Ford_Bronco_%286th_generation%29_Outer_Banks_1X7A0384.jpg", PricePerDay = 70.00m, YearOfManufacture = 2023, Mileage = 5000, FuelType = "Gasoline", Description = "Iconic off-road SUV.", IsAvailable = true, CarModel = "Bronco", CarBrandId = 3, CarTypeId = 1 },

                new Car { Name = "Ford Fusion", ImageUrl = "https://www.vdm.ford.com/content/dam/brand_ford/en_us/brand/cars/fusion/sunset/FL10383620_FUSI_Hyb_SE_34FrntPassStcVlctyBlueNight_mj_16x9.jpg/jcr:content/renditions/cq5dam.web.768.768.jpeg", PricePerDay = 46.00m, YearOfManufacture = 2020, Mileage = 22000, FuelType = "Hybrid", Description = "Comfortable midsize sedan.", IsAvailable = true, CarModel = "Fusion", CarBrandId = 3, CarTypeId = 2 },
                new Car { Name = "Ford Taurus", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bb/05-07_Ford_Taurus_SE_sedan.jpg/1200px-05-07_Ford_Taurus_SE_sedan.jpg", PricePerDay = 50.00m, YearOfManufacture = 2019, Mileage = 25000, FuelType = "Gasoline", Description = "Full-size sedan with space.", IsAvailable = true, CarModel = "Taurus", CarBrandId = 3, CarTypeId = 2 },
                new Car { Name = "Ford Focus", ImageUrl = "https://redriven.com/wp-content/uploads/2024/11/Ford-Focus-ST-1-scaled.jpg", PricePerDay = 40.00m, YearOfManufacture = 2018, Mileage = 30000, FuelType = "Gasoline", Description = "Compact and efficient.", IsAvailable = true, CarModel = "Focus", CarBrandId = 3, CarTypeId = 2 },

                new Car { Name = "Ford Focus ST", ImageUrl = "https://www.topgear.com/sites/default/files/cars-car/inline-gallery/2024/10/1-Ford-Focus-ST-Edition-review-2024.jpg", PricePerDay = 55.00m, YearOfManufacture = 2020, Mileage = 20000, FuelType = "Gasoline", Description = "Hot hatch performance model.", IsAvailable = false, CarModel = "Focus ST", CarBrandId = 3, CarTypeId = 3 },
                new Car { Name = "Ford Fiesta ST", ImageUrl = "https://images.carexpert.com.au/resize/3000/-/app/uploads/2022/09/ford-fiesta-st-58.jpg", PricePerDay = 50.00m, YearOfManufacture = 2019, Mileage = 25000, FuelType = "Gasoline", Description = "Small but sporty hatchback.", IsAvailable = true, CarModel = "Fiesta ST", CarBrandId = 3, CarTypeId = 3 },
                new Car { Name = "Ford Puma", ImageUrl = "https://www.topgear.com/sites/default/files/2024/09/Puma_IMHEV_ST_LINE_018.jpg", PricePerDay = 48.00m, YearOfManufacture = 2022, Mileage = 10000, FuelType = "Hybrid", Description = "Stylish subcompact crossover.", IsAvailable = true, CarModel = "Puma", CarBrandId = 3, CarTypeId = 3 },

                new Car { Name = "Ford Mustang Convertible", ImageUrl = "https://seven82files.s3.amazonaws.com/wp-content/uploads/2021/09/1965-Ford-Mustang-convertible-1.jpg", PricePerDay = 75.00m, YearOfManufacture = 2023, Mileage = 5000, FuelType = "Gasoline", Description = "Iconic American muscle car.", IsAvailable = true, CarModel = "Mustang Convertible", CarBrandId = 3, CarTypeId = 4 },
                new Car { Name = "Ford Thunderbird", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5b/1957_Ford_Thunderbird_%2828911503716%29_%28cropped%29.jpg", PricePerDay = 60.00m, YearOfManufacture = 2005, Mileage = 35000, FuelType = "Gasoline", Description = "Classic luxury convertible.", IsAvailable = true, CarModel = "Thunderbird", CarBrandId = 3, CarTypeId = 4 },
                new Car { Name = "Ford Focus CC", ImageUrl = "https://media.autoexpress.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1562250430/autoexpress/images/car_photo_216766.jpg", PricePerDay = 45.00m, YearOfManufacture = 2010, Mileage = 40000, FuelType = "Gasoline", Description = "Retractable hardtop convertible.", IsAvailable = true, CarModel = "Focus CC", CarBrandId = 3, CarTypeId = 4 },

                new Car { Name = "Chevrolet Tahoe", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/22/2022_Chevrolet_Tahoe_RST%2C_front_3.7.22.jpg", PricePerDay = 70.00m, YearOfManufacture = 2022, Mileage = 9000, FuelType = "Gasoline", Description = "Full-size family SUV.", IsAvailable = true, CarModel = "Tahoe", CarBrandId = 4, CarTypeId = 1 },
                new Car { Name = "Chevrolet Suburban", ImageUrl = "https://images.carexpert.com.au/resize/3000/-/app/uploads/2023/12/chevrolet-suburban-1.jpg", PricePerDay = 80.00m, YearOfManufacture = 2021, Mileage = 12000, FuelType = "Gasoline", Description = "Massive 9-seater SUV.", IsAvailable = true, CarModel = "Suburban", CarBrandId = 4, CarTypeId = 1 },
                new Car { Name = "Chevrolet Equinox", ImageUrl = "https://media.ed.edmunds-media.com/chevrolet/equinox/2022/oem/2022_chevrolet_equinox_4dr-suv_rs_fq_oem_1_1600.jpg", PricePerDay = 55.00m, YearOfManufacture = 2023, Mileage = 6000, FuelType = "Gasoline", Description = "Compact crossover SUV.", IsAvailable = true, CarModel = "Equinox", CarBrandId = 4, CarTypeId = 1 },

                new Car { Name = "Chevrolet Malibu", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Chevrolet_Malibu_LT_%28IX%2C_Facelift%29_%E2%80%93_f_02112024.jpg/1200px-Chevrolet_Malibu_LT_%28IX%2C_Facelift%29_%E2%80%93_f_02112024.jpg", PricePerDay = 48.00m, YearOfManufacture = 2022, Mileage = 12000, FuelType = "Gasoline", Description = "Comfortable midsize sedan.", IsAvailable = true, CarModel = "Malibu", CarBrandId = 4, CarTypeId = 2 },
                new Car { Name = "Chevrolet Impala", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Chevrolet_Impala_%2814373209694%29.jpg/330px-Chevrolet_Impala_%2814373209694%29.jpg", PricePerDay = 52.00m, YearOfManufacture = 2020, Mileage = 18000, FuelType = "Gasoline", Description = "Classic full-size sedan.", IsAvailable = true, CarModel = "Impala", CarBrandId = 4, CarTypeId = 2 },
                new Car { Name = "Chevrolet Sonic", ImageUrl = "https://cdn-fastly.thetruthaboutcars.com/media/2022/07/20/9417453/review-2012-chevrolet-sonic-lt.jpg?size=720x845&nocrop=1", PricePerDay = 38.00m, YearOfManufacture = 2019, Mileage = 25000, FuelType = "Gasoline", Description = "Compact budget sedan.", IsAvailable = false, CarModel = "Sonic", CarBrandId = 4, CarTypeId = 2 },

                new Car { Name = "Chevrolet Bolt EV", ImageUrl = "https://bucket.dealervenom.com/2023/10/design22CHBO35004_960x500.jpg?auto=compress%2Cformat&ixlib=php-3.3.1", PricePerDay = 45.00m, YearOfManufacture = 2023, Mileage = 5000, FuelType = "Electric", Description = "Affordable electric hatchback.", IsAvailable = true, CarModel = "Bolt EV", CarBrandId = 4, CarTypeId = 3 }
            };

            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].VIN = VINGenerator.GenerateVIN();
            }


            builder.Entity<Car>().HasData(cars);
        }
    }
}
