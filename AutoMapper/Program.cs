using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorModel, AuthorDTO>()
                .ForMember(dest => dest.Age, opts => opts.MapFrom(src => CaclulateYears(src.BirthDay)));
            });
            IMapper iMapper = config.CreateMapper();
            var source = new AuthorModel();

            source.Id = 1;
            source.FirstName = "Joydip";
            source.LastName = "Kanjulal";
            source.Address = "India";
            source.BirthDay = DateTime.Parse("30/12/1993");


            var destination = iMapper.Map<AuthorModel, AuthorDTO>(source);
            Console.Write("Author Name: " + destination.FirstName + " " + destination.LastName);
            Console.WriteLine(" was born " + destination.BirthDay.ToString() + ", so the author is "
                + destination.Age);
            Console.Read();
        }

        private static object CaclulateYears(DateTime birthDay)
        {
            return 1234;
        }
    }
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
    }
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age {
            get
            {
                return DateTime.Today.AddTicks(-BirthDay.Ticks).Year - 1;
            }
        }
    }
}
