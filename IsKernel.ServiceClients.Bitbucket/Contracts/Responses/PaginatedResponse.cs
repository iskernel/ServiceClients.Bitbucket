using System;
using Newtonsoft.Json;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.Responses
{
	public class PaginatedResponse<T> : PaginatedResponseBase
	{
		[JsonProperty("values")]
		public T[] Values {get;set;}
	}
}
