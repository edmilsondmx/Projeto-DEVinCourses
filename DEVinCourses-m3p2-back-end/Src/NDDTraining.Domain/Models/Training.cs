using System;
using System.Reflection;

namespace NDDTraining.Domain.Models
{
	public class Training
	{
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Active { get; set; }
        public string Category { get; set; }
        public virtual List<Module> Modules { get; set; }
        public Training()
		{

		}

        public Training(int id, string url, string title, string description, string teacher, TimeSpan duration, bool active, string category)
        {
            Id = id;
            Url = url;
            Title = title;
            Description = description;
            Teacher = teacher;
            Duration = duration;
            Active = active;
            Category = category;
        }
    }
}

