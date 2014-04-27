using System;
using System.Collections.Generic;
using RestSharp;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest
{
	public class RestComplexDataRequest : RestComplexRequest
	{
		public RestComplexDataRequest(Method method,
									  Dictionary<string, string> urlSegments = null,
									  Dictionary<string, string> parameters = null,
									  Dictionary<string, string> extraHeaders = null,
									  object content = null, 
									  RestDataContentType contentType = null)
			:base(method, urlSegments, parameters, extraHeaders)
		{
			ContentType = contentType;
			Content = content;
		}
		
		public object Content {get;set;}
		public RestDataContentType ContentType {get;set;}
	}
}
