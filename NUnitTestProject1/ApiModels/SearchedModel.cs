﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiAdMixer.ApiModels
{
    public class SearchedModel
    {
        public long Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<Result> Results { get; set; }


        public partial class Result
        {
            public string Name { get; set; }
            public long Height { get; set; }
            public long Mass { get; set; }
            public string HairColor { get; set; }
            public string SkinColor { get; set; }
            public string EyeColor { get; set; }
            public string BirthYear { get; set; }
            public string Gender { get; set; }
            public Uri Homeworld { get; set; }
            public List<Uri> Films { get; set; }
            public List<object> Species { get; set; }
            public List<Uri> Vehicles { get; set; }
            public List<Uri> Starships { get; set; }
            public DateTimeOffset Created { get; set; }
            public DateTimeOffset Edited { get; set; }
            public Uri Url { get; set; }
        }
    }
}
