using System.Diagnostics.Metrics;
using Viewer.Data;
using Viewer.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Viewer
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed(DataContext context)
        {
            _dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!_dataContext.Authors.Any())
            {                
                var authors = new List<Author>()
                {
                     new Author()
                     {
                         Name = "Slavik",

                         Books = new List<Book>()
                         {
                             new Book
                             {
                                 Name = "Consolidation",

                                 Genre = new Genre()
                                 {
                                     Name = "Fantastic"
                                 },
                                 Reviews = new List<Review>()
                                 {
                                     new Review { Title="Fantastic book",Text = "Some text about Consolidation",
                                     Reviewer = new Reviewer(){ Name = "babaka"} },
                                     new Review { Title="Sucks",Text = "Some bad text about sucks book Consolidation",
                                     Reviewer = new Reviewer(){ Name = "freak"} }
                                 }
                             }
                         }
                     },
                    new Author()
                     {
                         Name = "Mykyta",

                         Books = new List<Book>()
                         {
                             new Book
                             {
                                 Name = "Spoon",

                                 Genre = new Genre()
                                 {
                                     Name = "Drama"
                                 },
                                 Reviews = new List<Review>()
                                 {
                                     new Review { Title="Sadness",Text = "This is very sad story",
                                     Reviewer = new Reviewer(){ Name = "Dude"} }
                                 }
                             }
                         }
                     },
                     new Author()
                     {
                         Name = "Mike",
                     
                         Books = new List<Book>()
                         {
                             new Book
                             {
                                 Name = "World",
                     
                                 Genre = new Genre()
                                 {
                                     Name = "Shooter"
                                 },
                                 Reviews = new List<Review>()
                                 {
                                     new Review { Title="Sucks",Text = "It's sucks at all",
                                     Reviewer = new Reviewer(){ Name = "Bear"} }
                                 }
                             },
                             new Book
                             {
                                 Name = "Fire",
                     
                                 Genre = new Genre()
                                 {
                                     Name = "Fantasy"
                                 },
                                 Reviews = new List<Review>()
                                 {
                                     new Review { Title="Cool",Text = "Nice story...",
                                     Reviewer = new Reviewer(){ Name = "Digital bat"} }
                                 }
                             }
                         } 
                         
                     }
                };
               
                _dataContext.Authors.AddRange(authors);
                _dataContext.SaveChanges();

            }
           
        }
    }
}
