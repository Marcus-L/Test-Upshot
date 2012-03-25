using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace TestApp
{
    public class OData : DataService<ObjectContext>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
			config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

		protected override ObjectContext CreateDataSource()
		{
			var ctx = new TestEntities();
			var octx = ((IObjectContextAdapter)ctx).ObjectContext;
			octx.ContextOptions.ProxyCreationEnabled = false;
			return octx;
		}
    }
}
