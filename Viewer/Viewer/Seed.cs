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
                                     new Review { Title="Fantastic book",Text = "Some text",
                                     Reviewer = new Reviewer(){ Name = "Some Author"} }
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
                                     new Review { Title="Fantastic book",Text = "Some text",
                                     Reviewer = new Reviewer(){ Name = "Some Author"} }
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
                                     Name = "Fantastic"
                                 },
                                 Reviews = new List<Review>()
                                 {
                                     new Review { Title="Sucks",Text = "Some text",
                                     Reviewer = new Reviewer(){ Name = "Some Author"} }
                                 }
                             },
                             new Book
                             {
                                 Name = "Fire",
                     
                                 Genre = new Genre()
                                 {
                                     Name = "Fantastic"
                                 },
                                 Reviews = new List<Review>()
                                 {
                                     new Review { Title="Cool",Text = "Some text",
                                     Reviewer = new Reviewer(){ Name = "Some Author"} }
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
