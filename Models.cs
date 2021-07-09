using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFExample
{
  public class BloggingContext : DbContext
  {
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder opt)
      => opt.UseSqlite(@"Data Source=blog.sqlite");
  }

  public class Blog
  {
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
  }

  public class Author
  {
    public int AuthorId { get; set; }
    public string Name { get; set; }

    public List<Post> Posts { get; } = new();
  }

  public class Post
  {
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }
  }
}