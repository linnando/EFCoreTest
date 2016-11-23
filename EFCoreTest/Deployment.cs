using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreTest
{
    [TestClass]
    public class Deployment
    {
        [ClassInitialize]
        public static void PrepareTests(TestContext testContext)
        {
            using (var context = new BloggingContext())
            {
                context.Database.Migrate();
                if (!context.Blogs.Any(b => b.Url == "test"))
                    context.Blogs.Add(new Blog {Url = "test"});
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestBlog()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.FirstOrDefault(b => b.Url == "test");
                Assert.IsNotNull(blog);
            }
        }
    }
}
