namespace DoctorService
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Specialization Speciality { get; set; }
        public Gender Sex { get; set; }

        public int GetSimilarityScore(Doctor doctor)
        {
            var similarityScore = 0;
            similarityScore += IsSpecialitySimilar(doctor.Speciality) ? 1 : 0;
            similarityScore += IsAgeSimilar(doctor.Age) ? 1 : 0;
            similarityScore += IsSexSimilar(doctor.Sex) ? 1 : 0;
            return similarityScore;
        }

        private bool IsAgeSimilar(int age)
        {
            return age == Age;
        }

        private bool IsSpecialitySimilar(Specialization specialization)
        {
            return Speciality == specialization;
        }

        private bool IsSexSimilar(Gender sex)
        {
            return sex == Sex;
        }
    }
}
