using System;
using System.Collections.Generic;
using RestSharp;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest
{
	public class RestComplexRequest
	{
		public RestComplexRequest(Method method,
								 Dictionary<string, string> urlSegments = null,
								 Dictionary<string, string> parameters = null,
								 Dictionary<string, string> extraHeaders = null)
		{
			Method = method;
			UrlSegments = urlSegments;
			Parameters = parameters;
			ExtraHeaders = extraHeaders;
		}
		
		public Dictionary<string, string> UrlSegments {get;set;}
		public Dictionary<string, string> Parameters {get;set;}
		public Dictionary<string, string> ExtraHeaders {get;set;}
		public Method Method {get;set;}		
	}
}
