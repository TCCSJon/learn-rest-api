using Newtonsoft.Json;

namespace APIWrapper.Model
{
    public class Movie : BaseModel<Movie>
    {
        public long Id;
        public string name;
        public string genre;
        public int rating;
        private bool Deleted = false;

        [JsonConstructor]
        public Movie(long Id, string name, string genre, int rating)
        {
            this.Id = Id;
            this.name = name;
            this.genre = genre;
            this.rating = rating;
        }

        public Movie(string name, string genre, int rating)
        {           
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

        public string SerializeToString()
        {
            return string.Format(@"Id=""{0}"",""name""=""{1},""genre""=""{2}"",""rating""=""{3}"",""isDeleted""=""{4}""", this.Id, this.name, this.genre, this.rating, this.Deleted);
        }
    }
}
