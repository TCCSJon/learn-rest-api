using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleRESTAPIService.SampleData
{
    public class Movie
    {
        public long Id;
        public string name;
        public string genre;
        public int rating;
        private bool Deleted = false;

        
        public Movie(string name, string genre, int rating)
        {
            this.name = name;
            this.genre = genre;
            this.rating = rating;
        }

        [JsonConstructor]
        public Movie(long Id, string name, string genre, int rating)
        {
            this.Id = Id;
            this.name = name;
            this.genre = genre;
            this.rating = rating;
        }

        public bool isDeleted()
        {
            return this.Deleted;
        }

        public void DeleteMovie()
        {
            this.Deleted = true;
        }

        public long GetID()
        {
            return this.Id;
        }

        public void SetID(long Id)
        {
            this.Id = Id;
        }
    }
}
