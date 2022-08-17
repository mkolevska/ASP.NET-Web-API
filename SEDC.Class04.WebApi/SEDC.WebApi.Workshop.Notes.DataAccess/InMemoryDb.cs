using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.DataAccess
{
    public static class InMemoryDb
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User()
            {
                FirstName = "Marija",
                LastName = "Kolevska",
                Id = 1,
                NoteList = new List<Note>(),
                Password = "1234",
                Username = "12345"
            }
        };
        public static List<Note> Notes { get; set; } = new List<Note>
        {
            new Note()
            {
                Id = 1,
                Color = "Orange",
                Tag = 1,
                Text = "Hello",
                   User = new User()
                    {
                     FirstName = "Marija",
                     LastName = "Kolevska",
                     Id = 1,
                NoteList = new List<Note>(),
                Password = "1234",
                Username = "12345"
                },
                UserId = 1,

            },
              new Note()
            {
                Id = 2,
                Color = "Green",
                Tag = 1,
                Text = "Hello",
                User = new User()
                {
                    FirstName = "Marija",
                LastName = "Kolevska",
                Id = 1,
                NoteList = new List<Note>(),
                Password = "1234",
                Username = "12345"
                },
                UserId = 1,

            },

        };
    }
}
