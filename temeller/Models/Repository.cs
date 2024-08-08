namespace temeller.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses = new List<Course>();

        static Repository()
        {
            _courses = new List<Course>
            {
                new Course()
                {
                    Id = 1,
                    Title = "ASPNET KURSU",
                    Description = "Güzel bir kurs",
                    Image = "indir.jpg",
                    Tags = new string[] { "aspnet", "web geliştirme" },
                    IsActive = true,
                    IsHome = true
                },
                new Course()
                {
                    Id = 2,
                    Title = "C# KURSU",
                    Description = "Detaylı bir kurs",
                    Image = "indir.jpg",
                    Tags = new string[] { "PHP", "web geliştirme" },
                    IsActive = true,
                    IsHome = true
                },
                new Course()
                {
                    Id = 3,
                    Title = "JAVASCRIPT KURSU",
                    Description = "Pratik bir kurs",
                    Image = "indir.jpg",
                    IsActive = true,
                    IsHome = true
                },
                new Course()
                {
                    Id = 4,
                    Title = "PHP KURSU",
                    Description = "Pratik bir kurs",
                    Image = "indir.jpg",
                    IsActive = true,
                    IsHome = true
                }
            };
        }

        public static List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }

        #nullable enable
        public static Course? GetById(int id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }
        #nullable disable
    }
}
