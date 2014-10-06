using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace Flowers.Data.Model
{
    public class Flower : ObservableObject
    {
        public const string CommentsPropertyName = "Comments";
        public const string DescriptionPropertyName = "Description";
        public const string NamePropertyName = "Name";

        private string _description;
        private string _name;

        [JsonProperty("comments")]
        public ObservableCollection<Comment> Comments
        {
            get;
            set;
        }

        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                Set(() => Description, ref _description, value);
            }
        }

        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("image")]
        public string Image
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Set(() => Name, ref _name, value);
            }
        }

        public Flower()
        {
            Comments = new ObservableCollection<Comment>();
        }

        public void AddComment(string comment)
        {
            Comments.Add(
                new Comment
                {
                    Id = Guid.NewGuid().ToString(),
                    InputDate = DateTime.Now,
                    Text = comment
                });
        }

        public void DeleteComment(string id)
        {
            var comment = Comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                Comments.Remove(comment);
            }
        }
    }
}