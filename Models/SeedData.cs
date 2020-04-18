using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcH.Data;
using System;
using System.Linq;

namespace MvcH.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcHContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcHContext>>()))
            {

                if (context.Patient.Any())
                {
                    return;   // DB has been seeded
                }

                context.Patient.AddRange(
                    new Patient
                    {
                        FullName = "Sherlock Holmes",
                        AdmissionDate = DateTime.Parse("2020-4-17")
                    }
                );

                if (context.Hospital.Any())
                {
                    return;   // DB has been seeded
                }

                context.Hospital.AddRange(
                    new Hospital
                    {
                        Name = "London Hospital",
                        Address = "221b, Baker Street"
                    }
                );

                if (context.Room.Any())
                {
                    return;   // DB has been seeded
                }

                context.Room.AddRange(
                    new Room
                    {
                        Title = "Room 1"
                    }
                );

                if (context.Doctor.Any())
                {
                    return;   // DB has been seeded
                }

                context.Doctor.AddRange(
                    new Doctor
                    {
                        FullName = "Professor Moriarty",
                        HireDate = DateTime.Parse("2020-4-17"),
                        Specialty = SpecialtyEnum.Therapist
                    }
                );

                context.SaveChanges();
            }
        }
    }
}