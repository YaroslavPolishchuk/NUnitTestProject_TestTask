using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiAdMixer.ViewModels
{
    public class PeopleDTO
    {
        public string Name { get; set; }        
        public List<FilmDTO> Films { get; set; }       
        public string HomeWorld { get; set; }
        
        public Uri Url { get; set; }
    }
}
