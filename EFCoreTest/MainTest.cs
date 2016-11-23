using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreTest
{
    [TestClass]
    public class MainTest
    {
        private static BloggingContext _context;
        
        [ClassInitialize]
        public static void PrepareTests(TestContext testContext)
        {
            _context = new BloggingContext();
        }

        [TestMethod]
        public void TestGetByQueryableUrl()
        {
            var blogs1 = GetBlogsByQueryableUrl(new[] { "test" }.AsQueryable());
            System.Diagnostics.Debug.WriteLine(blogs1.Count());
            var blogs2 = GetBlogsByQueryableUrl(new[] { "wrong_url" }.AsQueryable());
            System.Diagnostics.Debug.WriteLine(blogs2.Count());
        }

        public IQueryable<Blog> GetBlogsByQueryableUrl(IQueryable<string> urls)
        {
            return _context.Blogs.Where(blog => urls.Contains(blog.Url));
        }

        [TestMethod]
        public void TestGetByEnumerableUrl()
        {
            var blogs1 = GetBlogsByEnumerableUrl(new[] { "test" }.AsQueryable());
            System.Diagnostics.Debug.WriteLine(blogs1.Count());
            var blogs2 = GetBlogsByEnumerableUrl(new[] { "wrong_url" }.AsQueryable());
            System.Diagnostics.Debug.WriteLine(blogs2.Count());
        }

        public IQueryable<Blog> GetBlogsByEnumerableUrl(IEnumerable<string> urls)
        {
            return _context.Blogs.Where(blog => urls.Contains(blog.Url));
        }
    }
}
