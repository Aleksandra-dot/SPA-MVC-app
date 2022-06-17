using SPA.Models;

namespace SPA.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(context != null)
                {
                    context.Database.EnsureCreated();

                    //Category
                    if (!context.Categories.Any())
                    {
                        context.Categories.AddRange(

                            new Category()
                            {
                                ProfilePictureUrl = "../wwwroot/Images/dlonie_stopy.jpg",
                                Name = "DŁONIE I STOPY",
                            },
                            new Category()
                            {
                                ProfilePictureUrl = "../wwwroot/Images/masaze_zabiegi_spa.jpg",
                                Name = "MASAŻE I ZABIEGI SPA",
                            },
                            new Category()
                            {
                                ProfilePictureUrl = "../wwwroot/Images/zabiegi_na_twarz.jpg",
                                Name = "ZABIEGI NA TWARZ",
                            },
                            new Category()
                            {
                                ProfilePictureUrl = "../wwwroot/Images/brwi_rzesy.jpg",
                                Name = "BRWI I RZĘSY",
                            }
                            );
                        context.SaveChanges();


                    }
                    //Service
                    if (!context.Services.Any())
                    {
                        context.Services.AddRange(
                            new Service
                            {
                                ProfilePictureUrl = "../wwwroot/Images/manicure_klasyczny.jpg",
                                Name = "Manicure klasyczny",
                                Description = "Zabieg obejmuje odsunięcie skórek, nadanie paznokciom kształtu, ewentualne skrócenie paznokci i ich wypolerowanie, nałożenie odżywki i lakieru",
                                Duration = 60,
                                Price = 90,
                                CategoryId = 1

                            },
                            new Service
                            {
                                ProfilePictureUrl = "../wwwroot/Images/manicure_hybrydowy.jpg",

                                Name = "Manicure hybrydowy",
                                Description = "Zabieg obejmuje odsunięcie skórek, nadanie paznokciom kształtu, ewentualne skrócenie paznokci i ich wypolerowanie, nałożenie odżywki i lakieru hybrydowego",
                                Duration = 60,
                                Price = 120,
                                CategoryId = 1

                            },
                             new Service
                             {
                                 ProfilePictureUrl = "../wwwroot/Images/pedicure.jpg",
                                 Name = "Pedicure klasyczny",
                                 Description = "Zabieg obejmuje pilling i masaż stóp, odsunięcie skórek, nadanie paznokciom kształtu, ewentualne skrócenie paznokci i ich wypolerowanie, nałożenie odżywki i lakieru hybrydowego",
                                 Duration = 60,
                                 Price = 100,
                                 CategoryId = 1

                             },
                             new Service
                             {
                                 ProfilePictureUrl = "../wwwroot/Images/czekolada.jpg",
                                 Name = "Masaż gorącą czekoladą",
                                 Description = "Masaż silnie relaksujący, nawilżający, oparty na kombinacji czekolady i olejków i eterycznych",
                                 Duration = 60,
                                 Price = 150,
                                 CategoryId = 2
                             },
                             new Service
                             {
                                 ProfilePictureUrl = "../wwwroot/Images/lomi.jpg",
                                 Name = "Masaż Lomi-Lomi",
                                 Description = "Masaż wywodzący się z wysp hawajskich - łączy w sobie elementy tańca, dotyku i masażu",
                                 Duration = 60,
                                 Price = 170,
                                 CategoryId = 2
                             },
                             new Service
                             {
                                 ProfilePictureUrl = "../wwwroot/Images/oczyszczanie_manulane.jpg",
                                 Name = "Manualne oczyszczanie twarzy",
                                 Description = "Pozwoli ci pozbyć sie zanieczyszczeń skórki i oczyścić zatkane pory",
                                 Duration = 60,
                                 Price = 100,
                                 CategoryId = 3
                             },
                             new Service
                             {
                                 ProfilePictureUrl = "../wwwroot/Images/henna_pudrowa.jpg",
                                 Name = "Henna pudrowa",
                                 Description = "Daje efekt optycznego przyciemnienia i zagęszczenia brwi",
                                 Duration = 60,
                                 Price = 90,
                                 CategoryId = 4
                             },
                             new Service
                             {
                                 ProfilePictureUrl = "../wwwroot/Images/laminacja_rzes.jpg",
                                 Name = "Lifting i laminacja rzęs",
                                 Description = "Daje efekt naturalnego i mocnego uniesienia rzęs",
                                 Duration = 60,
                                 Price = 179,
                                 CategoryId = 4
                             }
                             );
                        context.SaveChanges();




                    }
                    
                    //Employee
                    if (!context.Employees.Any())
                    {
                        context.Employees.AddRange(

                            new Employee
                            {
                                ProfilePictureUrl = "../wwwroot/Images/kaja.jpg",
                                Name = "Kaja",
                                LastName = "Morzych",
                            },
                            new Employee
                            {
                                ProfilePictureUrl = "../wwwroot/Images/ala.jpg",
                                Name = "Ala",
                                LastName = "Kowalczyk",
                            },
                            new Employee
                            {
                                ProfilePictureUrl = "../wwwroot/Images/ewa.jpg",
                                Name = "Ewa",
                                LastName = "Lubacka",
                            }

                            );
                        context.SaveChanges();

                    }

                    //Client
                    if (!context.Clients.Any())
                    {
                        context.Clients.AddRange(

                            new Client
                            {
                                Name = "Paulina",
                                LastName = "Kotarska",
                                PhoneNumber = "245678432"
                            },
                            new Client
                            {
                                Name = "Oliwia",
                                LastName = "Mlek",
                                PhoneNumber = "985641247"
                            },
                            new Client
                            {
                                Name = "Marcin",
                                LastName = "Pawelski",
                                PhoneNumber = "985428752"
                            }

                            );
                        context.SaveChanges();

                    }

                    //Appointment
                    if (!context.Appointments.Any())
                    {
                        context.AddRange(

                            new Appointment
                            {
                                Date = DateTime.Parse("2022-06-28"),
                                EmployeeId = 1,
                                ClientId = 1
                            },
                            new Appointment
                            {
                                Date = DateTime.Parse("2022-06-20"),
                                EmployeeId = 2,
                                ClientId = 3
                            },
                            new Appointment
                            {
                                Date = DateTime.Parse("2022-06-25"),
                                EmployeeId = 2,
                                ClientId = 2

                            }


                            );
                        context.SaveChanges();

                    }
                    //Service_Appointment
                    if (!context.Service_Appointments.Any())
                    {
                        context.AddRange(
                            new Service_Appointment
                            {
                                ServiceId = 1,
                                AppointmentId = 4,
                            },
                            new Service_Appointment
                            {
                                ServiceId = 3,
                                AppointmentId = 4,
                            },
                            new Service_Appointment
                            {
                                ServiceId = 4,
                                AppointmentId = 5,
                            },
                            new Service_Appointment
                            {
                                ServiceId = 1,
                                AppointmentId = 6,
                            },
                            new Service_Appointment
                            {
                                ServiceId = 8,
                                AppointmentId = 6,
                            }
                            );
                        context.SaveChanges();

                    }
                }




            }

        }
    }
}
