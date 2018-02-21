using System;

namespace HtppHeaders.Models
{
    public class HeaderStore
    {
        public int Id{get;set;}
        public string UserAgent{get;set;}

        public DateTime RequestDate{get;set;} = DateTime.Now;

    }
}