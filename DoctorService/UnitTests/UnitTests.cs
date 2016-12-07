using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorService
{
    class UnitTests
    {
        public static void Main(string[] args)
        {
            Test1();
        }

        public static void Test1()
        {
            DoctorLibrary library = new DoctorLibrary();
            library.AllDoctors.AddRange(new List<Doctor> {
                new Doctor
                {
                    Id = 1,
                    FirstName = "John ",
                    LastName = " Smith",
                    Age = 25,
                    Speciality = Specialization.Cardilogy,
                    Sex = Gender.Male
                },
                new Doctor
                {
                    Id = 2,
                    FirstName = "Rob",
                    LastName = "Jackson ",
                    Age = 25,
                    Speciality = Specialization.Cardilogy,
                    Sex = Gender.Male
                },

                   new Doctor
                {
                    Id = 3,
                    FirstName = "Don",
                    LastName = "Downey ",
                    Age = 25,
                    Speciality = Specialization.Orthopedic,
                    Sex = Gender.Male
                },
                   new Doctor
                {
                    Id = 4,
                    FirstName = "Jan",
                    LastName = "Coleman ",
                    Age = 25,
                    Speciality = Specialization.Cardilogy,
                    Sex = Gender.Female
                },
                   new Doctor
                {
                    Id = 5,
                    FirstName = "Aria",
                    LastName = "Jackson ",
                    Age = 25,
                    Speciality = Specialization.Pediatric,
                    Sex = Gender.Female
                }
            });
             var result =library.GetSimilarDoctors(new Doctor
            {
                Id = 3,
                FirstName = "Don",
                LastName = "Downey ",
                Age = 25,
                Speciality = Specialization.Orthopedic,
                Sex = Gender.Male
            });
            Assert.IsNotNull(result);

            Assert.IsTrue(result.Count == 5); // test that the result contains all the elements
            var i = 0;
            var previousSimilarityScore = 0;
            foreach (var doc in result)
            {
                if (i == 0)
                {
                    i++;
                    previousSimilarityScore = doc.Value;
                    continue;
                }
                Assert.IsTrue(doc.Value <= previousSimilarityScore); // test that the rcords are in descending order.
            }

      
        }
    }
}
