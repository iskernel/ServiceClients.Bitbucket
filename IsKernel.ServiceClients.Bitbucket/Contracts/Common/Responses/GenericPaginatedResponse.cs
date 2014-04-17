using System;
using Newtonsoft.Json;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses.Other;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses
{
	public class GenericPaginatedResponse<T> : PaginatedResponse
	{
		[JsonProperty("values")]
		public T[] Values {get;set;}
	}
}
