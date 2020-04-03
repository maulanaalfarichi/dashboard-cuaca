﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class weatherForcast
    {
        public city city {get;set;}
        public List<List> list { get; set; }//forecast list
    }
    public class city
    {
        public string name { get; set; }
    }
    
    public class temp
    {
        public double day { get; set; }
    }
    public class weather
    {
        public string main { get; set; }//weather condition
        public string description { get; set; }//weather description
        public string icon { get; set; }//weather icon id
    }
    public class List
    {
        public double dt { get; set; }//day in milli second
        public double pressure { get; set; }//pressure hpa
        public double humidity { get; set; }//humidity %
        public double speed { get; set; }//wind speed km/h
        public temp temp { get; set; }
        public List<weather>weather { get; set; }//weather list
    }
}
