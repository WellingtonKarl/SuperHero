using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHero.Domain.Model
{
    public class MarvelAuthentication
    {
        public long TimeStamp { get; set; }

        public string ApiKey { get; set; }

        public string HashMD5 { get; set; }
    }
}