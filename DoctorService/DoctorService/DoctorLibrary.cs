using System.Collections.Generic;
using System.Linq;

namespace DoctorService
{
    public class DoctorLibrary
    {
        public List<Doctor> AllDoctors { get; private set; }

        public DoctorLibrary()
        {
            AllDoctors = new List<Doctor>();
        }

        public Doctor GetDoctor(int id)
        {
            return AllDoctors.First(t => t.Id == id);
        }

        public Dictionary<Doctor, int> GetSimilarDoctors(Doctor doctor)
        {
            var similarityRanking = new Dictionary<int, int>();
            foreach (var doc in AllDoctors)
            {
                similarityRanking[doc.Id] = doc.GetSimilarityScore(doctor);
            }
            return similarityRanking.OrderByDescending(t => t.Value).ToDictionary(t => GetDoctor(t.Key), t => t.Value);
        }
    }
}
