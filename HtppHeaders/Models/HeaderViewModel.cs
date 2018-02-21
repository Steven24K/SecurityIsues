using System;
using System.Collections.Generic;

namespace HtppHeaders.Models
{
    public class HeaderViewModel
    {
        public KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> Header{get;set;}
        public int Amount{get;set;}
    }
}