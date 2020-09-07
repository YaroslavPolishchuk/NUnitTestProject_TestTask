using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiAdMixer.ApiModels
{
    public class Film
    {
        public List<Uri> Characters { get; set; }
        public DateTime Created { get; set; }
        public string Director { get; set; }
        public DateTime Edited { get; set; }
        public long EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public List<Uri> Planets { get; set; }
        public string Producer { get; set; }
        public string Release_Date { get; set; }
        public List<Uri> Species { get; set; }
        public List<Uri> Starships { get; set; }
        public string Title { get; set; }
        public Uri Url { get; set; }
        public List<Uri> Vehicles { get; set; }
    }
}
