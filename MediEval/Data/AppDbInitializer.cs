using MediEval.Data.Enums;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Grpc.Core;
using Microsoft.AspNetCore.Identity;
using MediEval.Data.Static;

namespace MediEval.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                _ = context.Database.EnsureCreated();

                //Orders
                if (!context.PharmaBrands.Any())
                {
                    context.PharmaBrands.AddRange(new List<PharmacyBrand>()
                    {
                        new PharmacyBrand()
                        {
                            Name = "Johnson & Johnson",
                            DosageForm = "Cream",
                            NDC_Code = "58232-4002-9",
                            category = MedicineCategory.PainReliever

                        },
                        new PharmacyBrand()
                        {
                            Name = "Advil",
                            DosageForm = "Tablet, Oral-Capsule",
                            NDC_Code = "66715-9700-2",
                            category = MedicineCategory.PainReliever

                        },
                        new PharmacyBrand()
                        {
                            Name = "Bayer",
                            DosageForm = "Tablet, Oral-Capsule",
                            NDC_Code = "66715-9700-2",
                            category = MedicineCategory.Vitamins

                        },
                        new PharmacyBrand()
                        {
                            Name = "Desyrel",
                            DosageForm = "Tablet, Oral-Capsule - 150 mg",
                            NDC_Code = "66715-9700-2",
                            category = MedicineCategory.antidepressants

                        },
                        new PharmacyBrand()
                        {
                            Name = "Protonix",
                            DosageForm = "Oral, Infusion ",
                            NDC_Code = "66715-9700-2",
                            category = MedicineCategory.Digestion

                        },

                    });
                    context.SaveChanges();
                }


                if (!context.Medicines.Any())
                {
                    
                    var brands = context.PharmaBrands.ToList();

                    context.Medicines.AddRange(new List<Medicine>()
                    {
                        new Medicine()
                        {
                            Name = "Neomycin",
                            Img = "~/images/neosporin.jpg",
                            Description = "This is the description of the first",
                            Quantity = 144,
                            weight = "0.9mg",
                            Price = 16.57,
                            MedicineCategory = MedicineCategory.PainReliever,
                            pharmaBrand = brands[0],
                        },
                        new Medicine()
                        {
                            Name = "Paracetamol",
                            Img = "~/images/neosporin.jpg",
                            Description = "This is the description of the Second",
                            Quantity = 144,
                            weight = "0.9mg",
                            Price = 16.57,
                            MedicineCategory = MedicineCategory.PainReliever,
                            pharmaBrand = brands[1],
                        },
                        new Medicine()
                        {
                            Name = "Aspirin",
                            Img = "~/images/neosporin.jpg",
                            Description = "This is the description of the Third",
                            Quantity = 125,
                            weight = "325mg",
                            Price = 7.99,
                            MedicineCategory = MedicineCategory.PainReliever,
                            pharmaBrand = brands[2],
                        },
                        new Medicine()
                        {
                            Name = "Desitin - Rash Cream",
                            Img = "~/images/neosporin.jpg",
                            Description = "This is the description of the Desitin",
                            Quantity = 1,
                            weight = "4oz",
                            Price = 6.55,
                            MedicineCategory = MedicineCategory.SkinCare,
                            pharmaBrand = brands[3],
                        },
                        new Medicine()
                        {
                            Name = "Citracal",
                            Img = "~/images/neosporin.jpg",
                            Description = "This is the description of the first cinema",
                            Quantity = 100,
                            weight = "400mg",
                            Price = 7.60,
                            MedicineCategory = MedicineCategory.Vitamins,
                            pharmaBrand = brands[4],
                        },
                    });
                    context.SaveChanges();
                }
                //Pharmacy

                if (!context.Pharmacies.Any())
                {
                    context.Pharmacies.AddRange(new List<Pharmacy>()
                    {
                        new Pharmacy()
                        {
                            PharmName = "Shoppers Drug Mart",
                            PharmAddress = "1300 Garth St, Hamilton, ON L9C 4L7",
                            PharmPhone = "(905) 331-6502"

                        },
                        new Pharmacy()
                        {
                            PharmName = "Pharmasave",
                            PharmAddress = "155 James St S, Hamilton, ON L8P 3A4",
                            PharmPhone = "(905) 527-5771"
                        },
                        new Pharmacy()
                        {
                            PharmName = "Remedy'sRx",
                            PharmAddress = "908 Garth St, Hamilton, ON L9C 4L2",
                            PharmPhone = "1-888-601-0663"


                        },
                        new Pharmacy()
                        {
                            PharmName = "Rexall",
                            PharmAddress = "2 King St W Unit 18, Hamilton, ON L8P 1A1",
                            PharmPhone = "(905) 529-6216"


                        },
                        new Pharmacy()
                        {
                            PharmName = "Shoppers Drug Mart",
                            PharmAddress = "3023 New St, Burlington, ON L7R 1K3",
                            PharmPhone = "(905) 632-4477"
                        },
                    });
                    context.SaveChanges();
                }
                //Pharmacy Medicine
                if (!context.Pharmacy_Medicines.Any())
                {
                    var pharmies = context.Pharmacies.ToList();
                    var medicines = context.Medicines.ToList();

                    context.Pharmacy_Medicines.AddRange(new List<Pharmacy_Medicine>()
                    {
                        new Pharmacy_Medicine()
                        {
                           pharmacy = pharmies[0],
                           medicine = medicines[0],
                        },
                        new Pharmacy_Medicine()
                        {
                               pharmacy = pharmies[1],
                           medicine = medicines[1],
                        },
                        new Pharmacy_Medicine()
                        {
                              pharmacy = pharmies[2],
                           medicine = medicines[2],


                        },
                        new Pharmacy_Medicine()
                        {

                           pharmacy = pharmies[3],
                           medicine = medicines[3],

                        },
                        new Pharmacy_Medicine()
                        {
                             pharmacy = pharmies[4],
                           medicine = medicines[4],
                        },
                    });
                    context.SaveChanges();
                }

                
            }
        }


        /**
         ******************************************************************************* 
         * SEEDING IDENTITY DATABASE / USER ROLES 
         *******************************************************************************
         * **/

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@medieval.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "newAdmin@mediEval1234?");  //password
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@medieval.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "newUser@mediEval1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }




        /*******************************************************************************/




    }
}
