using AutoMapper;
using Newtonsoft.Json;
using NUnit.Framework;
using RestApiAdMixer.ApiModels;
using RestApiAdMixer.ApiTool;
using RestApiAdMixer.FileWrite;
using RestApiAdMixer.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    [TestFixture]
    public class ApiTest
    {
        static public IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Film, FilmDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(s => s.Release_Date))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(s => s.Director));
            }).CreateMapper();
        }
        [Test]
        public void TestMethod()
        {
            var _mapper = GetMapper();

            SearchedModel finded = new SearchedModel();
            People model = new People();
            Planet planet = new Planet();
            Film film = new Film();
            List<FilmDTO> films = new List<FilmDTO>();

            string searching_object = "Luke Skywalker";
            string url = $"https://swapi.dev/api/people/?search={searching_object}";

            FetchTool client = new FetchTool();
            finded = client.Fetch<SearchedModel>(url);
            model = client.Fetch<People>(finded.Results[0].Url.ToString());
            planet = client.Fetch<Planet>(finded.Results[0].Homeworld.ToString());
            foreach (var uri in finded.Results[0].Films)
            {
                film = client.Fetch<Film>(uri.ToString());
                films.Add(_mapper.Map<FilmDTO>(film));
            }

            PeopleDTO returnModel = new PeopleDTO();
            returnModel.Name = model.Name;
            returnModel.HomeWorld = planet.Name;
            returnModel.Films = films;

            string fileInfo = JsonConvert.SerializeObject(returnModel);

            string time = $"Test had been passed at {DateTime.Now}";
            using (FileStream fs = new FileStream($"{FilePath.GetPath()}\\result.txt", FileMode.OpenOrCreate))
            {
                byte[] arr = Encoding.Default.GetBytes(fileInfo+time);
                fs.WriteAsync(arr, 0, arr.Length).GetAwaiter().GetResult();
                
            }

        }
    }
}
