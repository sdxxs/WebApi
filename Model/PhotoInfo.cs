namespace WebApi.Model
{
    public class PhotoInfo
    {

        public class Rootobject
        {
            public Photo photo { get; set; }
            public User user { get; set; }
        }

        public class Photo
        {
            public string id { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string color { get; set; }
            public string blur_hash { get; set; }
            public int likes { get; set; }
            public bool liked_by_user { get; set; }
            public string description { get; set; }
            public Urls urls { get; set; }
            public Links links { get; set; }
        }

        public class Urls
        {
            public string raw { get; set; } //!!!!
            public string full { get; set; }
            public string regular { get; set; }
            public string small { get; set; }
            public string thumb { get; set; }
        }

        public class Links
        {
            public string self { get; set; }
            public string html { get; set; }
            public string download { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public Links1 links { get; set; }
        }

        public class Links1
        {
            public string self { get; set; }
            public string html { get; set; }
            public string photos { get; set; }
            public string likes { get; set; }
        }

    }
}
