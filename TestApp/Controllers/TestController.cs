using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Data.EntityFramework;

namespace TestApp.Controllers
{
	public class TestController : DbDataController<TestEntities>
    {
		public IQueryable<ParentThing> GetParentThings()
		{
			return DbContext.ParentThings.Include("Children");
		}

		public HttpResponseMessage ReplaceThings()
		{
			using (var context = new TestEntities())
			{
				var firstParent = context.ParentThings.Include("Children").First();
				var firstChild = firstParent.Children.First();

				// remove the first item
				context.ChildThings.Remove(firstChild);

				// add an item to the end
				firstParent.Children.Add(new ChildThing
				{
					Name = "Added:"+DateTime.Now.ToString("G")
				});

				// save changes
				context.SaveChanges();
			}
			return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
		}
    }
}
