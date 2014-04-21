using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses
{
	public class PaginatedResponse<T> : PaginatedResponseBase
	{
		[JsonProperty("values")]
		public T[] Values {get;set;}
	}
}
