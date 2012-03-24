using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Runtime.Serialization;

namespace TestApp
{
	public class TestContextInitializer : DropCreateDatabaseIfModelChanges<TestEntities>
	{
		protected override void Seed(TestEntities context)
		{
			var parent = new ParentThing { Name = "TestParent" };
			for (int j = 0; j < 3; j++)
			{
				parent.Children.Add(new ChildThing { 
					Name = "Initial Item #"+j
				});
			}
			context.ParentThings.Add(parent);
		}
	}

	public class TestEntities : DbContext
	{
		public TestEntities() : base()
		{
			Database.SetInitializer<TestEntities>(new TestContextInitializer());
		}

		public DbSet<ParentThing> ParentThings { get; set; }
		public DbSet<ChildThing> ChildThings { get; set; }
	}

	public class ParentThing
	{
		public ParentThing()
		{
			Children = new HashSet<ChildThing>();
		}

		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public virtual ICollection<ChildThing> Children { get; set; }
	}

	public class ChildThing
	{
		[Key]
		public int ID { get; set; }
		public int Parent_Id { get; set; }
		public string Name { get; set; }

		[IgnoreDataMember]
		[ForeignKey("Parent_Id")]
		public virtual ParentThing Parent { get; set; }
	}
}