using System.Diagnostics.Metrics;
using Viewer.Data;
using Viewer.Models;

namespace Viewer
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Authors.Any())
            {
                new Author()
                {
                    //    Book = new Book()
                    //    {
                    //        Name = "Consolidation",
                    //        Genre = new Genre()
                    //        {
                    //            Name = "Fantastic"
                    //        },
                    //        Reviews = new List<Review>()
                    //            {
                    //                new Review { Title="Fantastic book",Text = "Some text",
                    //                Reviewer = new Reviewer(){ Name = "Some Author"} }
                    //            }
                    //    },

                };
                    
            }             
            dataContext.SaveChanges();
           
        }
    }
}
