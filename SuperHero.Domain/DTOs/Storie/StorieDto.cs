using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHero.Domain.DTOs.Storie
{
    public class StorieDto
    {
        public string code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public Data data { get; set; }
        public string etag { get; set; }
    }

    public class Data
    {
        public string offset { get; set; }
        public string limit { get; set; }
        public string total { get; set; }
        public string count { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string resourceURI { get; set; }
        public string type { get; set; }
        public string modified { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Comics comics { get; set; }
        public Series series { get; set; }
        public Events events { get; set; }
        public Characters characters { get; set; }
        public Creators creators { get; set; }
        public Originalissue originalissue { get; set; }
    }

    public class Thumbnail
    {
        public string path { get; set; }
        public string extension { get; set; }
    }

    public class Comics
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Series
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public Item1[] items { get; set; }
    }

    public class Item1
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Events
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public Item2[] items { get; set; }
    }

    public class Item2
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Characters
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public Item3[] items { get; set; }
    }

    public class Item3
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class Creators
    {
        public string available { get; set; }
        public string returned { get; set; }
        public string collectionURI { get; set; }
        public Item4[] items { get; set; }
    }

    public class Item4
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class Originalissue
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

}
