using System;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest
{
	public class RestDataContentType : ClassEnumBase<string>
	{
		private RestDataContentType(string value) : base(value)
		{
		}
		
		public static RestDataContentType Xml = new RestDataContentType("xml");
		public static RestDataContentType Json = new RestDataContentType("json");
		public static RestDataContentType QueryString = new RestDataContentType("querystring");
	}
}
