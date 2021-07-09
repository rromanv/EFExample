using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace EFExample
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var db = new BloggingContext())
      {
        // System.Console.WriteLine("Adding a new Blog with no posts");
        // db.Add(new Blog { Url = "https://google.com" });
        // db.Add(new Blog { Url = "https://southtexascollege.edu" });
        // db.SaveChanges();

        printAll();

        // System.Console.WriteLine("Get Blog with Id = 2");
        // Blog blog2 = db.Blogs.Where<Blog>(b => b.BlogId == 2).First();
        // System.Console.WriteLine($"{blog2.Url}");
        // System.Console.WriteLine();

        // System.Console.WriteLine("Updating google to something else");
        // blog2.Url = "https://rodolforoman.xyz";
        // blog2.Posts.Add(
        //   new Post { Title = "My new Post", Content = "With very interesting information" }
        //   );
        // Post secondPost = new() { Title = "Second Post", Content = "Another relevant content" };
        // blog2.Posts.Add(secondPost);
        // db.SaveChanges();
        // System.Console.WriteLine($"{blog2.Url}");

        // Blog blog3 = db.Blogs.Where<Blog>(b => b.BlogId == 3).First();
        // db.Remove(blog3);
        // db.SaveChanges();

        // printAll();

      }


    }

    public static void printAll()
    {
      using (var db = new BloggingContext())
      {

        List<Blog> blogs = db.Blogs.Include(b => b.Posts).ToList<Blog>();
        System.Console.WriteLine("Get all Blogs");
        blogs.ForEach(b =>
        {
          System.Console.WriteLine($"{b.BlogId} - {b.Url}");
          b.Posts
            .OrderByDescending(p => p.PostId)
            .ToList<Post>()
            .ForEach(p => Console.WriteLine($"\t{p.PostId} - {p.Title} by {p.Author}"));
        });
        System.Console.WriteLine();
      }
    }
  }
}
