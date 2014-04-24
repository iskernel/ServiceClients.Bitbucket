using System;
using NUnit.Framework;

namespace IsKernel.ServieClients.Bitbucket.Tests.TestHelpers
{
	public static class AssertHelper
	{
		public static void AtLeastOnePropertyIsNotDefault<T>(T model)
		{
			var type = typeof(T);
			bool condition = false;
			foreach (var property in type.GetProperties())
			{
				var value = property.GetValue(model, null);
				if( value != null )
				{
					condition = true;
					break;
				}
 			}
			Assert.IsTrue(condition);		
		}
	}
}
