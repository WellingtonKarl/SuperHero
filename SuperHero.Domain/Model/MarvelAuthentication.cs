using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHero.Domain.Model
{
    public class MarvelAuthentication
    {
        public long TimeStamp { get; }

        public string ApiKey { get; }

        public string HashMD5 { get; }
    }
}